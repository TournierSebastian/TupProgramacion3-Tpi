
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.ViewModel;

namespace Service.IService
{
    public interface IProductService
    {

        string AddProducts(ProductsViewModel products); 
        List<DtoProducts> GetAllProducts();
        List<DtoProducts> GetProductsById(int id);
        string DeleteProductByID(int id);
        string ModifyProductById(int id, ProductsViewModel product);
    }
}
