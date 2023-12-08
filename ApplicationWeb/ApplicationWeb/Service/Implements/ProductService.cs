using ApplicationWeb.Data;
using ApplicationWeb.Data.Entities;
using ApplicationWeb.Data.Repository.Interfaces;
using ApplicationWeb.Data.ViewModel;
using AutoMapper;
using Service.IService;


namespace Service.Service
{
    public class ProductService : IProductService
    {
        private readonly TiendaContext _TiendaContext;
        private readonly IMapper _mapper;
        private readonly  IProductsRepository _productsRepository;
        public ProductService(TiendaContext TiendaContext, IMapper mapper, IProductsRepository productsRepository)
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
        public List<Products> GetAllProducts()
        {
            var products = _productsRepository.GetProducts().Where(x => x.Stock > 0).ToList();
            return products;
        }
        public Products GetProductsById(int id)
        {

            var products = _productsRepository.GetProductsById(id);
            if(products.Stock <= 0)
            {
                return null;
            }

            return products;
        }

        public string DeleteProductByID(int id)
        {

            var products = _productsRepository.GetProductsById(id);

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
            var productModify = _productsRepository.GetProductsById(id);
           
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
