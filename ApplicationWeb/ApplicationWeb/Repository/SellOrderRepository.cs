using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApplicationWeb.Repository
{
    public class SellOrderRepository
    {
        private TiendaContext _TiendaContext;
        public SellOrderRepository(TiendaContext TiendaContext)
        {

            _TiendaContext = TiendaContext;

        }

        public List<SellOrder> GetSellOrder()
        {
            var Orders = _TiendaContext.SellOrders.Include(order => order.OrdenDetails).ToList();
            return Orders;
        }

    }
}
