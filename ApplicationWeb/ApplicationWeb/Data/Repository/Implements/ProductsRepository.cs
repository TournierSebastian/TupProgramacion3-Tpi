using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Repository.Interfaces;

namespace ApplicationWeb.Repository
{
    public class ProductsRepository : IProductsRepository
    {

        private TiendaContext _TiendaContext;
        public ProductsRepository(TiendaContext TiendaContext)
        {

            _TiendaContext = TiendaContext;

        }


        public List<Products> GetProducts()
        {
            var products = _TiendaContext.Products.ToList();
            return products;
        }

        public Products GetProductsById(int id) {
            var products = _TiendaContext.Products.FirstOrDefault(x=> x.idProducts == id);
            return products;
        }
    }
}
