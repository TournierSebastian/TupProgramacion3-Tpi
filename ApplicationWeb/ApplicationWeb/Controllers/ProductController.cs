using AplicacionWeb.Controllers;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace ApplicationWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {


        private readonly IProductService _AdminService;

        private readonly ILogger _logger;

        public ProductController(IProductService adminService, ILogger<ProductController> logger)
        {
            _logger = logger;
            _AdminService = adminService;
        }




       
        [HttpGet("GetAllProducts")]
        public ActionResult<List<Products>> GetAllProducts()
        {
            try
            {
                string role = User.Claims.SingleOrDefault(x => x.Type.Contains("role")).Value;
                if (role == "Admin" || role == "Customer")
                {
                    var Response = _AdminService.GetAllProducts();

                    if (Response == null)
                    {
                        return NotFound("Products Not Found");
                    }
                    return Ok(Response);
                }
                else
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

        [HttpGet("GetProductsByid/{id}")]
        public ActionResult<Products> GetProductsById(int id)
        {
            try
            {
                string role = User.Claims.SingleOrDefault(x => x.Type.Contains("role")).Value;
                if (role == "Admin")
                {
                    var Response = _AdminService.GetProductsById(id);

                    if (Response == null)
                    {
                        return NotFound("Product Not Found");
                    }
                    return Ok(Response);
                }
                else
                {
                    return NotFound("Incorrect Role");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in GetProductById: {ex}");
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPost("AddProduct")]
        public ActionResult<String> AddProducts([FromBody] ProductsViewModel products)
        {

            try
            {
                string role = User.Claims.SingleOrDefault(x => x.Type.Contains("role")).Value;
                if (role == "Admin")
                {
                    var Response = _AdminService.AddProducts(products);
                    if (Response == null)
                    {
                        return NotFound("incomplete data");
                    }
                    return Ok($"added product");
                }
                else
                {
                    return NotFound("Incorrect Role");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in AddProduct: {ex}");
                return BadRequest($"{ex.Message}");
            }
        }
        [HttpDelete("DeleteProductsById / {id}")]
        public ActionResult<string> DeleteProductById(int id)
        {
            try
            {
                string role = User.Claims.SingleOrDefault(x => x.Type.Contains("role")).Value;
                if (role == "Admin")
                {
                    var Response = _AdminService.DeleteProductByID(id);

                    if (Response == "Product Not Found")
                    {
                        return NotFound("Product Not Found");
                    }
                    return Ok(Response);
                }
                else
                {
                    return NotFound("Incorrect Role");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in GetProductById: {ex}");
                return BadRequest($"{ex.Message}");
            }

        }
        [HttpPut("ModifyProductById / {id}")]
        public ActionResult<string> ModifyProductById(int id, [FromBody] ProductsViewModel product)
        {
            try
            {
                string role = User.Claims.SingleOrDefault(x => x.Type.Contains("role")).Value;
                if (role == "Admin")
                {
                    var Response = _AdminService.ModifyProductById(id, product);

                    if (Response != "Modified Product")
                    {
                        return NotFound("Unmodified product");
                    }
                    return Ok(Response);

                }
                else
                {
                    return NotFound("Incorrect Role");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in ModifyProductById: {ex}");
                return BadRequest($"{ex.Message}");
            }


        }


    }


}
