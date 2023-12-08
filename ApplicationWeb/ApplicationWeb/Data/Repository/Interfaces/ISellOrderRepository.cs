
using ApplicationWeb.Data.Entities;
using ApplicationWeb.Data.Models;

namespace ApplicationWeb.Data.Repository.Interfaces
{
    public interface ISellOrderRepository
    {
        List<SellOrderGetDto> GetSellOrder();
        List<SellOrderGetDto> GetOrderByUserid(int id);

        SellOrder GetSellOrderByid(int id);
    }
}
