using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.ViewModel;
using AutoMapper;
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

        

        public DtoProducts AddProducts(ProductsViewModel products)
        {
            
            if (products == null || products.Name == "" || products.Descripcion == "" || products.Price == 0 || products.Stock == 0)
            {
                return null;
            }

            var productos = new DtoProducts
            {
                Name = products.Name,
                Price = products.Price,
                Descripcion = products.Descripcion,
                Stock = products.Stock,
                
            };
            _TiendaContext.DtoProducts.Add(productos);
            _TiendaContext.SaveChanges();
            return productos;
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

        public string ModifyProductById(int id, ProductsViewModel product)
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
