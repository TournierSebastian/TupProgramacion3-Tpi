using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;
using ApplicationWeb.Data.ViewModel;
using AutoMapper;

namespace ApplicationWeb.Mapping.Profiles
{
    public class SellOrderProfile : Profile
    {
         public SellOrderProfile()
        {
            CreateMap<SellOrder, DtoSellOrder>();
            CreateMap<SellOrderViewMode, SellOrder>();
        }
    }
}
