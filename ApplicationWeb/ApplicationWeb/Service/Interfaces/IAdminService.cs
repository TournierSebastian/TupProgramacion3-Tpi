
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.ViewModel;

namespace Service.IService
{
    public interface IAdminService
    {

        DtoProducts AddProducts(ProductsViewModel products); 
        List <DtoProducts> GetAllProducts();
        DtoProducts GetProductsById(int id);
        string DeleteProductByID(int id);
        string ModifyProductById(int id, ProductsViewModel product);
    }
}
