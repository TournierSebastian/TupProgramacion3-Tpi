using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Models;

namespace ApplicationWeb.Data.Repository.Interfaces
{
    public interface ISellOrderRepository
    {
        List<DtoSellOrderGet> GetSellOrder();
        List<DtoSellOrderGet> GetOrderByUserid(int id);

        SellOrder GetSellOrderByid(int id);
    }
}
