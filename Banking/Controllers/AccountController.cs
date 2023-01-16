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
    public class AccountController : ControllerBase
    {

        private IAccountService _accountService;
        IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("registeAccount")]
        public IActionResult RegisterAccount([FromBody] CreateNewAccountDto model)
        {
            var account = _mapper.Map<Account>(model);
            Console.WriteLine("Generate Randoms!");

            var random = RandomNumberGenerator.Create();
            var bytes = new byte[sizeof(int)]; // 4 bytes
            random.GetNonZeroBytes(bytes);
            var result = BitConverter.ToInt32(bytes);

            Console.WriteLine($"{result}");
            return Ok(_accountService.CreateAccount(account, model.Password, model.ConfirmPassword));
        }


        [HttpPost]
        [Route("deleteAccount")]
        public void DeleteAccount(int Id)

        {

            _accountService.DeleteAccount(Id);

        }


        [HttpGet]
        [Route("GetNumberOfAccounts")]
        public IActionResult GetNumberOfAccounts() {
            return Ok(_accountService.GetNumberOfAccounts());
        }
        [HttpGet]
        [Route("getAccountBalance")]
        public IActionResult getAccountBalance(int Id)

        {

            return  Ok(_accountService.getAccountById(Id));

        }


        [HttpGet]
        [Route("getAllAccounts")]
        public IActionResult getAllAccounts()

        {

            return Ok(_accountService.getAllAccounts());

        }
        [HttpGet]
        [Route("getAccountByAccountNumber")]
        public IActionResult getAccountByAccountNumber(string accountNumber)

        {

            return Ok(_accountService.getAccountbyAccountNumber(accountNumber));

        }
        [HttpGet]
        [Route("getAccountBalanceByAccountNumber")]
        public IActionResult getAccountBalanceByAccountNumber(string accountNumber)

        {

            return Ok(_accountService.GetAccountBalance(accountNumber));

        }


        [HttpPost]
        [Route("Login")]
        public IActionResult loginCustomer(string accountNumber , string Password)

        {
            return Ok(_accountService.Authenticate(accountNumber, Password));

        }
    }
}
