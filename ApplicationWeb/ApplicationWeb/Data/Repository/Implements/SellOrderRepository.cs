using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApplicationWeb.Repository
{
    public class SellOrderRepository : ISellOrderRepository
    {
        private TiendaContext _TiendaContext;
        public SellOrderRepository(TiendaContext TiendaContext)
        {

            _TiendaContext = TiendaContext;

        }

        public List<DtoSellOrderGet> GetSellOrder()
        {
            var Orders = _TiendaContext.SellOrders.Include(order => order.OrdenDetails).ToList();
            List<DtoSellOrderGet> SellOrder = Orders
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
            List<DtoSellOrderGet> SellOrder = _TiendaContext.SellOrders
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

        public SellOrder GetSellOrderByid(int id)
        {
            var sellOrder = _TiendaContext.SellOrders.FirstOrDefault(order => order.idOrder == id);
            return sellOrder;
        } 
    
    }
}
