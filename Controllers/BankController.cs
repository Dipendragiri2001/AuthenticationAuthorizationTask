using InficareTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InficareTask.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankInitializer _bankInitializer;
        public BankController(BankInitializer bankInitializer)
        {
            _bankInitializer = bankInitializer;
        }
        [HttpGet]
        public List<Bank> GetBanks()
        {
            return _bankInitializer.GetBanks();
        }
    }
}