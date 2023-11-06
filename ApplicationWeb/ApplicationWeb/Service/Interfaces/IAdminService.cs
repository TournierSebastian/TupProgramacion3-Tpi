

using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;

namespace Service.IService
{
    public interface IAdminService
    {

        DtoProducts AddProducts(DtoProducts products); 
        List <DtoProducts> GetAllProducts();
        DtoProducts GetProductsById(int id);
        string DeleteProductByID(int id);
        string ModifyProductById(int id, Products product);
    }
}
