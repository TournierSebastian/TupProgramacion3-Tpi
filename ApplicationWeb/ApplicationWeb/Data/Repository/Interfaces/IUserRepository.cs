
using ApplicationWeb.Data.Entities;

namespace ApplicationWeb.Data.Repository.Interfaces
{
    public interface IUserRepository
    {

        List<User> GetallUser();

        User GetUser(string Email,string UserName);

        User GetUserByid (int id);
    }
}
