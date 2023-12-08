
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.ViewModel;

namespace ApplicationWeb.Service.Interfaces
{
    public interface IUserService
    {
        UserDto AddUser(UserViewModel user);
        List<UserGetDto> GetAllUser();
        string DeleteUserByid(int id);

    }
}
