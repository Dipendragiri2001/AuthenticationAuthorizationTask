using InficareTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InficareTask.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerInitializer _bankInitializer;
        public CustomerController(CustomerInitializer bankInitializer )
        {
            _bankInitializer = bankInitializer;
        }
        [HttpGet]
        public List<Customer> GetCustomers()
        {
            return _bankInitializer.GetCustomers();
        }
    }
}