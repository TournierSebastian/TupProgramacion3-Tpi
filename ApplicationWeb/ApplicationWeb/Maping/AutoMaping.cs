using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.ViewModel;
using AutoMapper;

namespace ApplicationWeb.Maping
{
    public class AutoMaping : Profile
    {
        public AutoMaping() { 
        
        CreateMap<DtoUser, User>();
        CreateMap<User, DtoUser>();
        CreateMap<UserViewModel, User>();

        CreateMap<DtoProducts, Products>();
        CreateMap<Products, DtoProducts>();
        CreateMap<ProductsViewModel, Products>();
            

        CreateMap<SellOrder, DtoSellOrder>();
        CreateMap<SellOrderViewMode, SellOrder>();



        }
    }
}
