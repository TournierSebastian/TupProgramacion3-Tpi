using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;
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
            var user = _TiendaContext.DtoUsers.FirstOrDefault(x => x.idUser == Sellorden.UserId);

            if (Sellorden.PayMethod == "")
            {
                return "Incomplete Data";
            }
            var orden = new DtoSellOrder
            {

                PayMethod = Sellorden.PayMethod,
                QuantityProducts = Sellorden.QuantityProducts,
                TotalValue = product.Price * Sellorden.QuantityProducts,
                Name = product.Name,
                Price = product.Price,
                Descripcion = product.Descripcion,
                UserName = user.UserName,
                Email = user.Email,
            };
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
                _TiendaContext.Remove(order);
                _TiendaContext.SaveChanges();
                return "Sell Order deleted";

            }
                
        }
        public List<DtoSellOrder> GetallOrder()
        {

            var order = _TiendaContext.DtoSellOrders.ToList();
            return order;

        }


        public DtoSellOrder GetOrderById(int id)
        {
            var order = _TiendaContext.DtoSellOrders.FirstOrDefault(x => x.idOrder == id);

            return order;
        }



        public List<DtoProducts> GetAllProducts()
        {
            var products = _TiendaContext.DtoProducts.ToList();
            return products;
        }
    }
}
