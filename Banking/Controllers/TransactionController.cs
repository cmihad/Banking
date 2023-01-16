using AutoMapper;
using Banking.Models;
using Banking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Banking.Controllers
{
    [ApiController]
    [Route("api/v1/")]
 
        public class TransactionController : ControllerBase
    {
        private  ITransactionService _transactionService;

        private IAccountService _accountService;
        IMapper _mapper;
        public TransactionController(IAccountService accountService, IMapper mapper ,ITransactionService transactionService)
        {
            _accountService = accountService;
            _mapper = mapper;
            _transactionService = transactionService;
        }
        [HttpPost]
        [Route("withdraw")]
        public IActionResult withdraw(string AccountNumber, decimal amount )
        {
            return Ok(_transactionService.WIthdraw(AccountNumber, amount));
        }
        [HttpPost]
        [Route("deposit")]
        public IActionResult deposit(string AccountNumber, decimal amount)
        {
            return Ok(_transactionService.Deposit(AccountNumber, amount));
        }

        [HttpGet]
        [Route("numberOfTransactionbyAcccount")]
        public IActionResult numberOfTransactionByAccount(string AccountNumber)
        {
            return Ok(_transactionService.TotalNumberOfTransactions(AccountNumber));
        }
        
        [HttpGet]
        [Route("generateReport")]
        public IActionResult generateReport(string AccountNumber)
        {
            return Ok(_transactionService.GenerateReport(AccountNumber));
        }
    }
}
