
using ApplicationWeb.Data.Entities;
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.ViewModel;
using AutoMapper;

namespace ApplicationWeb.Maping
{
    public class AutoMaping : Profile
    {
        public AutoMaping() { 
   
        CreateMap<User, UserDto>();
        CreateMap<UserViewModel, User>();

  
        CreateMap<ProductsViewModel, Products>();
            

        CreateMap<SellOrderViewMode, SellOrder>();



        }
    }
}
