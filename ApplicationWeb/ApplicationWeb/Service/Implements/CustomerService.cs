using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;
using ApplicationWeb.Data.ViewModel;

using ApplicationWeb.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationWeb.Service.Implements
{
    public class CustomerService : ICustomerService
    {

        private readonly TiendaContext _TiendaContext;
      
        public CustomerService(TiendaContext context)
        {   
            _TiendaContext = context;
        }


        public string AddSellOrder([FromBody] SellOrderViewMode Sellorden)
        {
            var product = _TiendaContext.DtoProducts.FirstOrDefault(x => x.idProducts == Sellorden.Productid);
            var user = _TiendaContext.DtoUsers.FirstOrDefault(x => x.UserName == Sellorden.UserName);

         
            if (product == null || user == null || product.Stock <= 0 || product.Stock < Sellorden.QuantityProducts||
               Sellorden.PayMethod.ToUpper() != "EFECTIVO" && Sellorden.PayMethod.ToUpper() != "TARJETA")
            {
                return "Incomplete Data";
            }

           
            var orden = new DtoSellOrder
            {

                PayMethod = Sellorden.PayMethod,
                QuantityProducts = Sellorden.QuantityProducts,
                TotalValue = product.Price * Sellorden.QuantityProducts,
                idProduct = Sellorden.Productid,
                Name = product.Name,
                Price = product.Price,
                Descripcion = product.Descripcion,
                idUser = user.idUser,
                UserName = user.UserName,
                Email = user.Email,
                Validation = true
            };


            product.Stock = product.Stock - Sellorden.QuantityProducts;
            _TiendaContext.Add(orden);
            _TiendaContext.SaveChanges();

            return "Added SellOrder";
        }

        public string DeleteOrderByid(int orderid)
        {
            var order = _TiendaContext.DtoSellOrders.FirstOrDefault(x => x.idOrder == orderid);
            
            string response = string.Empty;

            if (order == null)
            {
                return "Sell Order not found";
            }
       
            else
            {
                var product = _TiendaContext.DtoProducts.FirstOrDefault(x => x.idProducts == order.idProduct);
                product.Stock += order.QuantityProducts;
                _TiendaContext.Remove(order);
                _TiendaContext.SaveChanges();
                return "Sell Order deleted";

            }
                
        }
        public List<DtoSellOrder> GetallOrder()
        {


            var order = _TiendaContext.DtoSellOrders.Where(order => order.Validation == true).ToList();

            return order;

        }


        public DtoSellOrder GetOrderByUserName(string UserName)
        {
            var order = _TiendaContext.DtoSellOrders.FirstOrDefault(x => x.UserName == UserName);

            return order;
        }
        


        public List<DtoProducts> GetAllProducts()
        {
            var products = _TiendaContext.DtoProducts.Where(product => product.Stock > 0).ToList();
            return products;
        }
    }
}
