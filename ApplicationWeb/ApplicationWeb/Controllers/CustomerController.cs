using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.ViewModel;
using ApplicationWeb.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AplicacionWeb.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _ICustomerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService ICustomerService, ILogger<CustomerController> looger)
        {
            _ICustomerService = ICustomerService;
            _logger = looger;
        }

    }
}

