using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;

namespace ApplicationWeb.Repository
{
    public class ProductsRepository
    {

        private TiendaContext _TiendaContext;
        public ProductsRepository(TiendaContext TiendaContext)
        {

            _TiendaContext = TiendaContext;

        }


        public List<Products> GetProducts()
        {
            var Orders = _TiendaContext.Products.ToList();
            return Orders;
        }
    }
}
