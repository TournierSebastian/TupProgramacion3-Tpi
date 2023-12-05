using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.ViewModel;

namespace ApplicationWeb.Service.Interfaces
{
    public interface IUserService
    {
        User AddUser(UserViewModel user);
        List<DtoUser> GetAllUser();
        string DeleteUserByid(int id);

    }
}
