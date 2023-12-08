using ApplicationWeb.Data;
using ApplicationWeb.Data.Entities;
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.Repository.Interfaces;
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

        public List<SellOrderGetDto> GetSellOrder()
        {
            var Orders = _TiendaContext.SellOrders.Include(order => order.OrdenDetails).ToList();
            List<SellOrderGetDto> SellOrder = Orders
           .Where(order => order.Validation == true)
           .Select(order => new SellOrderGetDto
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


        public List<SellOrderGetDto> GetOrderByUserid(int id)
        {
            List<SellOrderGetDto> SellOrder = _TiendaContext.SellOrders
              .Where(order => order.Validation == true && order.idUser == id)
              .Select(order => new SellOrderGetDto
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
