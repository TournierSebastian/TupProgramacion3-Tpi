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

        [HttpGet("GetAllProducts")]
        public ActionResult<List<DtoProducts>> GetAllProducts()
        {
            string role = User.Claims.SingleOrDefault(x => x.Type.Contains("role")).Value;

            try
            {
                if( role == "Customer")
                {
                var Response = _ICustomerService.GetAllProducts();
                
                if (Response == null)
                {
                    return NotFound("Products Not Found");
                }
                return Ok(Response);
                }else
                {
                   return NotFound("Incorrect Role");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in GetAllProduct: {ex}");
                return BadRequest($"{ex.Message}");
            }
        }


        [HttpGet("GetAllOrders")]
        public ActionResult<List<DtoSellOrder>> GetallOrder()
        {
            try
            {
                 string role = User.Claims.SingleOrDefault(x => x.Type.Contains("role")).Value;
                 if (role == "Customer")
                 {
                var response = _ICustomerService.GetallOrder();
                if (response == null || response.Count == 0)
                {

                    return NotFound("Sell orders not found");
                }

                return Ok(response);
                 }
                 else
                 {
                     return NotFound("Incorrect Role");
                 }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in GetallOrder: {ex}");
                return BadRequest($"{ex.Message}");
            }


        }
        [HttpGet("GetOrderByUserName/{UserName}")]
        public ActionResult<DtoSellOrder> GetOrderByUserName(string UserName)
        {
            try
            {
                string role = User.Claims.SingleOrDefault(x => x.Type.Contains("role")).Value;

                 if (role == "Customer")
                {        
                var response = _ICustomerService.GetOrderByUserName(UserName);
                if (response == null)
                {
                    return NotFound("Sell order not found");
                }
                return Ok(response);
                 }
                 else{
                    return NotFound("Incorrect Role");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in GetOrderById: {ex}");
                return BadRequest($"{ex.Message}");
            }

        }

        [HttpPost("AddSellOrder")]

        public ActionResult<string> AddSellOrder([FromBody] SellOrderViewMode orden)
        {
            try
            {
                string role = User.Claims.SingleOrDefault(x => x.Type.Contains("role")).Value;

                if (role == "Customer")
                {

                var response = _ICustomerService.AddSellOrder(orden);
                if (response == "Incomplete Data")
                {
                    return BadRequest("Error in AddSellOrder ");
                }

                return Ok("Added SellOrder");
                }else{
                    return NotFound("Incorrect Role");
                 }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in AddSellOrder: {ex}");
                return BadRequest($"{ex.Message}");
            }

        }
        [HttpDelete("DeleteOrder{orderid}")]

        public ActionResult<string> DeleteOrderByid(int orderid)
        {
            var response = _ICustomerService.DeleteOrderByid(orderid);
            try
            {
                 string role = User.Claims.SingleOrDefault(x => x.Type.Contains("role")).Value;
                if (role == "Customer")
                {
                if (response == "Sell Order deleted")
                {
                    return Ok("Sell Order deleted");
                }
                return NotFound("Sell Order not found");
                 }
                else
                {
                     return NotFound("Incorrect Role");
                  }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in DeleteOrderByid: {ex}");
                return BadRequest($"{ex.Message}");
            }

        }



    }
}

