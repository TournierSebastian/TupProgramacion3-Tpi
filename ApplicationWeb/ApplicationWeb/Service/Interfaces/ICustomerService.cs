
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.ViewModel;

namespace ApplicationWeb.Service.Interfaces
{
    public interface ICustomerService
    {

        List<DtoSellOrder> GetallOrder();

        List<DtoSellOrder> GetOrderByUserid(int id);
        string AddSellOrder(SellOrderViewMode orden);
        string DeleteOrderByid(int orderId);


    }

}
