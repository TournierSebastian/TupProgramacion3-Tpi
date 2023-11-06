
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;
using ApplicationWeb.Data.ViewModel;
using AutoMapper;

namespace ApplicationWeb.Config.Profiles
{
    public class UserProfile: Profile
    {
         public UserProfile()
        {
            CreateMap<User, DtoUser>();
            CreateMap<UserViewModel, User>();
        }
    }
}
