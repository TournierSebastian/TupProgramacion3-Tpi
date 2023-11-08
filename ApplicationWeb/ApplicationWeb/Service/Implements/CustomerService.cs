
using ApplicationWeb.Config;
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
        private readonly IMapper _mapper;
        public CustomerService(TiendaContext context)
        {
            _TiendaContext = context;
            _mapper = AutoMapperConfig.Configure();
        }


        public string AddSellOrder(int id, [FromBody] SellOrderViewMode Sellorden)
        {
            var product = _TiendaContext.DtoProducts.FirstOrDefault(x => x.idProducts == id);
          
            if (Sellorden.PayMethod == "")
            {
                return "Incomplete Data";
            }
            var user = new DtoSellOrder
            {
                TotalValue = product.Price,
                PayMethod = Sellorden.PayMethod,
            };
          
            _TiendaContext.Add(user);
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
