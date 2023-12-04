using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Service.IService;

namespace AplicacionWeb.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase

    {
        private readonly IAdminService _AdminService;

        private readonly ILogger _logger;

        public AdminController(IAdminService adminService, ILogger<AdminController> logger)
        {
            _logger = logger;
            _AdminService = adminService;
        }

    }
}
