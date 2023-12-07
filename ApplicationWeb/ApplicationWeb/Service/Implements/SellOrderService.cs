using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.ViewModel;
using ApplicationWeb.Repository;
using ApplicationWeb.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing.Text;

namespace ApplicationWeb.Service.Implements
{
    public class SellOrderService : ISellOrderService
    {

        private readonly TiendaContext _TiendaContext;
        private readonly IMapper _mapper;
        private readonly SellOrderRepository _SellOrderRepository;
        public SellOrderService(TiendaContext context, IMapper mapper, SellOrderRepository sellOrderRepository)
        {
            _TiendaContext = context;
            _mapper = mapper;
            _SellOrderRepository = sellOrderRepository;
        }


        public string AddSellOrder([FromBody] SellOrderViewMode Sellorden)
        {
            var user = _TiendaContext.Users.FirstOrDefault(x => x.idUser == Sellorden.Userid);

                var orderDetailsList = new List<OrderDetails>();
                int totalValue = 0;
                SellOrder orden;
                orden = _mapper.Map<SellOrder>(Sellorden);           
                orden.idUser = user.idUser;
                orden.UserName = user.UserName;
                orden.Email = user.Email;
                orden.Validation = true;

            foreach (var productos in Sellorden.Products)
                {

                    var product = _TiendaContext.Products.FirstOrDefault(x => x.idProducts == productos.Productid);
                    if (product == null|| product.Stock <= 0 || product.Stock < productos.QuantityProducts)
                    {
                        return "Incomplete Data";
                    }
               
                    var orders = new OrderDetails
                   {
                       Productsid = product.idProducts,
                        Name = product.Name,
                        Price = product.Price,
                        Descripcion = product.Descripcion,
                        QuantityProducts = productos.QuantityProducts,
                        
                    };

                orderDetailsList.Add(orders);
                    _TiendaContext.Add(orders);

                    product.Stock = product.Stock - orders.QuantityProducts;
                    totalValue += product.Price * productos.QuantityProducts;
                }

            orden.OrdenDetails = orderDetailsList;
            orden.TotalValue = totalValue;
            if (Sellorden.PayMethod.ToUpper() != "EFECTIVO" && Sellorden.PayMethod.ToUpper() != "TARJETA" || user == null)
                {
                    return "Incomplete Data";
                }

                _TiendaContext.SellOrders.Add(orden);

                _TiendaContext.SaveChanges();
                return "Added SellOrder";

        }

        public string DeleteOrderByid(int orderid)
        {
            var orders = _SellOrderRepository.GetSellOrder();
            var order = orders.FirstOrDefault(x => x.idOrder == orderid);


            if (order == null)
            {
                return "Sell Order not found";
            }

            else
            {
                foreach (var x in order.OrdenDetails)
                {
                    var product = _TiendaContext.Products.FirstOrDefault(producto => producto.idProducts == x.Productsid);
                    if (product != null)
                    {
                            product.Stock += x.QuantityProducts;
                      
                    }

                }
                
                _TiendaContext.Remove(order);
                _TiendaContext.SaveChanges();
                return "Sell Order deleted";

            }
        }
                
      
        public List<DtoSellOrderGet> GetallOrder()
        {
            var orders = _SellOrderRepository.GetSellOrder();
            List<DtoSellOrderGet> SellOrder = orders
                .Where(order => order.Validation == true)
                .Select(order => new DtoSellOrderGet
                {
                    idOrder = order.idOrder,
                    PayMethod = order.PayMethod,
                    TotalValue = order.TotalValue,
                    UserName = order.UserName,
                    Email = order.Email,
                    OrdenDetails = order.OrdenDetails

                }).ToList();

            return SellOrder;

        }


        public List<DtoSellOrderGet> GetOrderByUserid(int id)
        {

            var orders = _SellOrderRepository.GetSellOrder();

            List<DtoSellOrderGet> SellOrder = orders
                    .Where(order => order.Validation == true && order.idUser == id)
                    .Select(order => new DtoSellOrderGet
                    {
                        idOrder = order.idOrder,
                        PayMethod = order.PayMethod,
                        TotalValue = order.TotalValue,
                        UserName = order.UserName,
                        Email = order.Email,
                        OrdenDetails = order.OrdenDetails,
                   
                    })
                    .ToList();
            return SellOrder;
        }
        
    }
}
