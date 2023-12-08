
using ApplicationWeb.Data.Entities;
using ApplicationWeb.Data.ViewModel;

namespace Service.IService
{
    public interface IProductService
    {

        string AddProducts(ProductsViewModel products);
        List<Products> GetAllProducts();
        
        Products GetProductsById(int id);
        string DeleteProductByID(int id);
        string ModifyProductById(int id, ProductsViewModel product);
    }
}
