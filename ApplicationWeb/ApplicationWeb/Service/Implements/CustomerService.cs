using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;
using ApplicationWeb.Data.Models;
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
            var product = _TiendaContext.Products.FirstOrDefault(x => x.idProducts == Sellorden.Productid);
            var user = _TiendaContext.Users.FirstOrDefault(x => x.idUser == Sellorden.Userid);

         
            if (product == null || user == null || product.Stock <= 0 || product.Stock < Sellorden.QuantityProducts||
               Sellorden.PayMethod.ToUpper() != "EFECTIVO" && Sellorden.PayMethod.ToUpper() != "TARJETA")
            {
                return "Incomplete Data";
            }

           
            var orden = new SellOrder
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
            var order = _TiendaContext.SellOrders.FirstOrDefault(x => x.idOrder == orderid);
            
            string response = string.Empty;

            if (order == null)
            {
                return "Sell Order not found";
            }
       
            else
            {
                var product = _TiendaContext.Products.FirstOrDefault(x => x.idProducts == order.idProduct);
                product.Stock += order.QuantityProducts;
                _TiendaContext.Remove(order);
                _TiendaContext.SaveChanges();
                return "Sell Order deleted";

            }
                
        }
        public List<DtoSellOrder> GetallOrder()
        {


            //var order = _TiendaContext.SellOrders.Where(order => order.Validation == true)

   
            List<DtoSellOrder> order = _TiendaContext.SellOrders.Where(order => order.Validation == true).Select(order =>new DtoSellOrder
            {
                idOrder = order.idOrder,
                PayMethod = order.PayMethod,
                QuantityProducts = order.QuantityProducts,
                TotalValue = order.TotalValue,
                Name = order.Name,
                Price = order.Price,
                Descripcion = order.Descripcion,
                UserName = order.UserName,
                Email = order.Email

            }).ToList();
  
        
            return order;

        }


        public List<DtoSellOrder> GetOrderByUserid(int id)
        {

            List<DtoSellOrder> order = _TiendaContext.SellOrders.Where(order => order.Validation == true && order.idUser == id).Select(order => new DtoSellOrder
            {
                idOrder = order.idOrder,
                PayMethod = order.PayMethod,
                QuantityProducts = order.QuantityProducts,
                TotalValue = order.TotalValue,
                Name = order.Name,
                Price = order.Price,
                Descripcion = order.Descripcion,
                UserName = order.UserName,
                Email = order.Email

            }).ToList();

            return order;
        }
        
    }
}
