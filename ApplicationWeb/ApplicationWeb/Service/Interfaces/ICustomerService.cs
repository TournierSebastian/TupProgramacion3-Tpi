﻿
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.ViewModel;

namespace ApplicationWeb.Service.Interfaces
{
    public interface ICustomerService
    {

        List<DtoSellOrder> GetallOrder();

        DtoSellOrder GetOrderById(int id);
        string AddSellOrder(int id, SellOrderViewMode orden);
        string DeleteOrderByid(int orderId);
        List<DtoProducts> GetAllProducts();

    }

}
