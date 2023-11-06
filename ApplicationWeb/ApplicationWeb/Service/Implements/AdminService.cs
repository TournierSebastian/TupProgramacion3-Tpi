
using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;
using Service.IService;


namespace Service.Service
{
    public class AdminService : IAdminService
    {
        private readonly TiendaContext _TiendaContext;
            

        public AdminService(TiendaContext TiendaContext)
        {
            _TiendaContext = TiendaContext;
        }

        

        public DtoProducts AddProducts(DtoProducts products)
        {
            
            if (products == null || products.Name == "" || products.Descripcion == "" || products.Price == 0)
            {
                return null;
            }
            _TiendaContext.DtoProducts.Add(products);
            _TiendaContext.SaveChanges();
            return products;
        }
        public List <DtoProducts> GetAllProducts()
        {
             var products = _TiendaContext.DtoProducts.ToList();
            return products;
        }
        public  DtoProducts GetProductsById(int id)
        {
            var productsId = _TiendaContext.DtoProducts.FirstOrDefault(x => x.idProducts == id);
            return productsId;
        }

        public string DeleteProductByID(int id)
        {
            var products = _TiendaContext.DtoProducts.FirstOrDefault(x => x.idProducts == id);
            if(products == null) 
            {
                return ("Product Not Found");            
            }
            _TiendaContext.Remove(products);
            _TiendaContext.SaveChanges();
            return ("Product Delete");

        }

        public string ModifyProductById(int id, Products product)
        {
            var productModify = _TiendaContext.DtoProducts.FirstOrDefault(x => x.idProducts == id);
            if (product == null || product.Name == "" || product.Descripcion == "" || product.Price == 0)
            {
                return (" Incomplete Data ");
            }

            productModify.Name = product.Name;
            productModify.Descripcion = product.Descripcion;
            productModify.Price = product.Price;
            _TiendaContext.SaveChanges();
            return ("Modified Product");

        }
    }
    
}
