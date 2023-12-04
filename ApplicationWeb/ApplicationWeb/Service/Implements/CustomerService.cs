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

            using (var transaction = _TiendaContext.Database.BeginTransaction())
            {
                //var product = _TiendaContext.Products.FirstOrDefault(x => x.idProducts == Sellorden.Productid);
                var user = _TiendaContext.Users.FirstOrDefault(x => x.idUser == Sellorden.Userid);

                var orderDetailsList = new List<OrderDetails>();
                int totalValue = 0;

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
                        SellOrderId = 0
                    };

                    _TiendaContext.Add(orders);

                    product.Stock = product.Stock - orders.QuantityProducts;
                    totalValue += product.Price * productos.QuantityProducts;
                }
            

                if (//product == null || user == null || product.Stock <= 0 || product.Stock < Sellorden.QuantityProducts||
                   Sellorden.PayMethod.ToUpper() != "EFECTIVO" && Sellorden.PayMethod.ToUpper() != "TARJETA" || user == null)
                {
                    return "Incomplete Data";
                }


                var orden = new SellOrder
                {

                    PayMethod = Sellorden.PayMethod,

                    ///////TotalValue = product.Price * Sellorden.QuantityProducts,
                    //QuantityProducts = Sellorden.QuantityProducts,
                    //idProduct = Sellorden.Productid,
                    //Name = product.Name,
                    //Price = product.Price,
                    //Descripcion = product.Descripcion,
                    idUser = user.idUser,
                    UserName = user.UserName,
                    Email = user.Email,
                    Validation = true,
                    TotalValue = totalValue
                    
                };


                //// product.Stock = product.Stock - Sellorden.QuantityProducts;
                _TiendaContext.Add(orden);

                _TiendaContext.SaveChanges();
                int sellOrderId = orden.idOrder;

                foreach (var productos in Sellorden.Products)
                {
                    var ordendetail = _TiendaContext.OrderDetails.FirstOrDefault(x => x.Productsid == productos.Productid && x.SellOrderId == 0);
                    if (ordendetail != null)
                    {
                        ordendetail.SellOrderId = sellOrderId;
                    }
                }
                _TiendaContext.SaveChanges();
                transaction.Commit();
                return "Added SellOrder";
        
            }
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
                //var product = _TiendaContext.Products.FirstOrDefault(x => x.idProducts == order.idProduct);
                //product.Stock += order.QuantityProducts;
                _TiendaContext.Remove(order);
                _TiendaContext.SaveChanges();
                return "Sell Order deleted";

            }
                
        }
        public List<DtoSellOrder> GetallOrder()
        {


            //var order = _TiendaContext.SellOrders.Where(order => order.Validation == true)


            List<DtoSellOrder> orders = _TiendaContext.SellOrders
                    .Where(order => order.Validation == true)
                    .Select(order => new DtoSellOrder
                    {
                        idOrder = order.idOrder,
                        PayMethod = order.PayMethod,
                        TotalValue = order.TotalValue,
                        UserName = order.UserName,
                        Email = order.Email,
                        OrderDetails = _TiendaContext.OrderDetails
                            .Where(od => od.SellOrderId == order.idOrder)
                            .Select(od => new DtoOrderDetail
                            {
                                Productsid = od.Productsid,
                                QuantityProducts = od.QuantityProducts,
                                Name = od.Name,
                                Price = od.Price,
                                Descripcion = od.Descripcion
                            })
                            .ToList()
                    })
                    .ToList();

            return orders;

        }


        public List<DtoSellOrder> GetOrderByUserid(int id)
        {
            List<DtoSellOrder> orders = _TiendaContext.SellOrders
                    .Where(order => order.Validation == true && order.idUser == id)
                    .Select(order => new DtoSellOrder
                    {
                        idOrder = order.idOrder,
                        PayMethod = order.PayMethod,
                        TotalValue = order.TotalValue,
                        UserName = order.UserName,
                        Email = order.Email,
                        OrderDetails = _TiendaContext.OrderDetails
                            .Where(od => od.SellOrderId == order.idOrder)
                            .Select(od => new DtoOrderDetail
                            {
                                Productsid = od.Productsid,
                                QuantityProducts = od.QuantityProducts,
                                Name = od.Name,
                                Price = od.Price,
                                Descripcion = od.Descripcion
                            })
                            .ToList()
                    })
                    .ToList();
            return orders;
        }
        
    }
}
