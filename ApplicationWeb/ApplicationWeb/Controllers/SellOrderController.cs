using AplicacionWeb.Controllers;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.ViewModel;
using ApplicationWeb.Service.Implements;
using ApplicationWeb.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SellOrderController : ControllerBase
    {

        private readonly ISellOrderService _ICustomerService;
        private readonly ILogger _logger;

        public SellOrderController(ISellOrderService ICustomerService, ILogger<SellOrderController> looger)
        {
            _ICustomerService = ICustomerService;
            _logger = looger;
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
        [HttpGet("GetOrderByUserid/{id}")]
        public ActionResult<List<SellOrder>> GetOrderByUserid(int id)
        {
            try
            {
                string role = User.Claims.SingleOrDefault(x => x.Type.Contains("role")).Value;

                if (role == "Customer")
                {
                    var response = _ICustomerService.GetOrderByUserid(id);
                    if (response == null)
                    {
                        return NotFound("Sell order not found");
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
            }
            else
            {
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
