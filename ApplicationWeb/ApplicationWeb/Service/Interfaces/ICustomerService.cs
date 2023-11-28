
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.ViewModel;

namespace ApplicationWeb.Service.Interfaces
{
    public interface ICustomerService
    {

        List<DtoSellOrder> GetallOrder();

        DtoSellOrder GetOrderByUser(int id);
        string AddSellOrder(SellOrderViewMode orden);
        string DeleteOrderByid(int orderId);
        List<DtoProducts> GetAllProducts();

    }

}
