using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Models;

namespace ApplicationWeb.Data.Repository.Interfaces
{
    public interface IProductsRepository
    {
       List<Products> GetProducts();
       Products GetProductsById(int id);
    }

}
