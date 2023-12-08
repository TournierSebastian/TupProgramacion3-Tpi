
using ApplicationWeb.Data.Entities;

namespace ApplicationWeb.Data.Repository.Interfaces
{
    public interface IProductsRepository
    {
       List<Products> GetProducts();
       Products GetProductsById(int id);
    }

}
