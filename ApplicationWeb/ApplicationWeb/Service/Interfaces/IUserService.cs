using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.ViewModel;

namespace ApplicationWeb.Service.Interfaces
{
    public interface IUserService
    {
        DtoUser AddUser(UserViewModel user);
        List<DtoUserGet> GetAllUser();
        string DeleteUserByid(int id);

    }
}
