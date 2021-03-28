using AutoMapper;
using BankAPI.Data;
using BankAPI.Dto;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    [Route("api/transfers")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly TransferSqlRepo _transferRepo;
        private readonly AccountSqlRepo _accountRepo;
        private readonly IMapper _mapper;

        public TransferController(TransferSqlRepo transferRepo, AccountSqlRepo accountRepo, IMapper mapper)
        {
            _transferRepo = transferRepo;
            _accountRepo = accountRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransferReadDTO>> GetTransfers()
        {
            var transfers = _transferRepo.GetTransfers();
            return Ok(_mapper.Map<IEnumerable<TransferReadDTO>>(transfers));
        }

        [HttpGet("{id}", Name = "GetTransferById")]
        public ActionResult<TransferReadDTO> GetTransferById(int id)
        {
            var transfer = _transferRepo.GetTransferById(id);

            if (transfer != null) return Ok(_mapper.Map<TransferReadDTO>(transfer));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<TransferCreateDTO> MakeTransfer(TransferCreateDTO transferCreateDTO)
        {
            var transferModel = _mapper.Map<Transfer>(transferCreateDTO);
            var senderModel = _accountRepo.GetAccountById(transferModel.SenderID);
            var receiverModel = _accountRepo.GetAccountById(transferModel.ReceiverID);

            if (senderModel == null)
            {
                return Problem("Sender doesn't exist.", default, 400, "Bad transfer request.");
            } 
            
            if (receiverModel == null)
            {
                return Problem("Reciever doesn't exist.", default, 400, "Bad transfer request.");
            }

            if (senderModel.Balance < transferModel.Amount)
            {
                return Problem("Unsufficient balance.", default, 400, "Bad transfer request.");
            }

            senderModel.Balance -= transferModel.Amount;
            receiverModel.Balance += transferModel.Amount;

            DateTime currentTime = DateTime.UtcNow;
            transferModel.TimeStamp = currentTime;

            _transferRepo.MakeTransfer(transferModel, senderModel, receiverModel);
            var transferReadDTO = _mapper.Map<TransferReadDTO>(transferModel);
             
            return CreatedAtRoute(
                nameof(GetTransferById),
                new { transferReadDTO.Id },
                transferReadDTO
            );
        }
    }
}
