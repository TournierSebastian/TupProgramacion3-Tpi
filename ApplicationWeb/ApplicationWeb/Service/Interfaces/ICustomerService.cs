
using ApplicationWeb.Data.Dto;


namespace ApplicationWeb.Service.Interfaces
{
    public interface ICustomerService
    {

        List<DtoSellOrder> GetallOrder();

        DtoSellOrder GetOrderById(int id);
        string AddSellOrder(int id, DtoSellOrder orden);
        string DeleteOrderByid(int orderId);
        List<DtoProducts> GetAllProducts();

    }

}
