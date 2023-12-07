using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.ViewModel;
using ApplicationWeb.Repository;
using AutoMapper;
using Service.IService;


namespace Service.Service
{
    public class ProductService : IProductService
    {
        private readonly TiendaContext _TiendaContext;
        private readonly IMapper _mapper;
        private readonly  ProductsRepository _productsRepository;
        public ProductService(TiendaContext TiendaContext, IMapper mapper, ProductsRepository productsRepository)
        {
            _TiendaContext = TiendaContext;
            _mapper = mapper;
            _productsRepository = productsRepository;

        }

        

        public string AddProducts(ProductsViewModel products)
        {
            
            if (products == null || products.Name == "" || products.Descripcion == "" || products.Price == 0 || products.Stock == 0)
            {
                return null;
            }


            Products productos;

            productos = _mapper.Map<Products>(products);


            _TiendaContext.Add(productos);
            _TiendaContext.SaveChanges();
            return "Product Added";

        }
        public List<DtoProducts> GetAllProducts()
        {
            var products = _productsRepository.GetProducts();
            List<DtoProducts> product = products.Where(x => x.Stock > 0 ).Select(product => new DtoProducts
            {
                idProducts = product.idProducts,
                Name = product.Name,
                Price = product.Price,
                Descripcion = product.Descripcion,
                Stock = product.Stock,
            }).ToList();

            return product;
        }
        public List<DtoProducts> GetProductsById(int id)
        {

            var products = _productsRepository.GetProducts();
            var productsId = products.FirstOrDefault(x => x.idProducts == id && x.Stock > 0);

            List<DtoProducts> Products = new List<DtoProducts>
            {
              new DtoProducts
              {
                 idProducts = productsId.idProducts,
                 Name = productsId.Name,
                 Price = productsId.Price,
                 Descripcion = productsId.Descripcion,
                 Stock = productsId.Stock,
              }
            };


            return Products;
        }

        public string DeleteProductByID(int id)
        {

            var productos = _productsRepository.GetProducts();
            var products = productos.FirstOrDefault(x => x.idProducts == id);
            if(products == null) 
            {
                return ("Product Not Found");            
            }




            
            var sellOrders = _TiendaContext.SellOrders
          .Where(order =>  order.OrdenDetails.Any(od => od.Productsid == id))
        .ToList();

            foreach (var sellOrder in sellOrders)
            {
                 sellOrder.Validation = false;
            }


            _TiendaContext.Remove(products);
            _TiendaContext.SaveChanges();
            return ("Product Delete");

        }

        public string ModifyProductById(int id, ProductsViewModel product)
        {
            var products = _productsRepository.GetProducts();
            var productModify = products.FirstOrDefault(x => x.idProducts == id);
            if (product == null || product.Name == "" || product.Descripcion == "" || product.Price == 0)
            {
                return (" Incomplete Data ");
            }

            productModify.Descripcion = product.Descripcion;
            productModify.Price = product.Price;
            productModify.Stock = product.Stock;
            _TiendaContext.SaveChanges();
            return ("Modified Product");

        }
    }
    
}
