﻿using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Models;
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

        

        public Products AddProducts(ProductsViewModel products)
        {
            
            if (products == null || products.Name == "" || products.Descripcion == "" || products.Price == 0 || products.Stock == 0)
            {
                return null;
            }

            var productos = new Products
            {
                Name = products.Name,
                Price = products.Price,
                Descripcion = products.Descripcion,
                Stock = products.Stock,
                
            };
            _TiendaContext.Products.Add(productos);
            _TiendaContext.SaveChanges();
            return productos;
        }
        public List<DtoProducts> GetAllProducts()
        {

            List<DtoProducts> product = _TiendaContext.Products.Select(product => new DtoProducts
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
            var productsId = _TiendaContext.Products.FirstOrDefault(x => x.idProducts == id);

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
            var products = _TiendaContext.Products.FirstOrDefault(x => x.idProducts == id);
            if(products == null) 
            {
                return ("Product Not Found");            
            }

     
            var sellOrders = _TiendaContext.SellOrders.Where(x => x.idProduct == id);

   
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
            var productModify = _TiendaContext.Products.FirstOrDefault(x => x.idProducts == id);
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
