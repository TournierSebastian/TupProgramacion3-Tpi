
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.ViewModel;

namespace ApplicationWeb.Service.Interfaces
{
    public interface ISellOrderService
    {

        List<DtoSellOrderGet> GetallOrder();

        List<DtoSellOrderGet> GetOrderByUserid(int id);
        string AddSellOrder(SellOrderViewMode orden);
        string DeleteOrderByid(int orderId);


    }

}
