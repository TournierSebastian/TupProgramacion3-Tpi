
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.ViewModel;
using ApplicationWeb.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Service.IService;
using System.Data;

namespace AplicacionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SuperAdminController : ControllerBase
    {
        private readonly ISuperAdminService _SuperAdminService;
        private readonly ILogger _logger;


        public SuperAdminController(ISuperAdminService superAdminService, ILogger<SuperAdminController> logger, IAuthService authService)
        {
            _SuperAdminService = superAdminService;
            _logger = logger;
        }

    }
}
