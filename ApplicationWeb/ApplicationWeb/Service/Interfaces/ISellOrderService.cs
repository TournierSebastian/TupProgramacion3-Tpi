
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.ViewModel;

namespace ApplicationWeb.Service.Interfaces
{
    public interface ISellOrderService
    {

        List<SellOrderGetDto> GetallOrder();

        List<SellOrderGetDto> GetOrderByUserid(int id);
        string AddSellOrder(SellOrderViewMode orden);
        string DeleteOrderByid(int orderId);


    }

}
