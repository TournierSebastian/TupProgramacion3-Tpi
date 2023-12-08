
using ApplicationWeb.Data.Entities;
using ApplicationWeb.Data.Repository.Interfaces;

namespace ApplicationWeb.Data.Repository.Implements
{
    public class UserRepository: IUserRepository
    {
        private TiendaContext _TiendaContext;
        public UserRepository(TiendaContext TiendaContext)
        {

            _TiendaContext = TiendaContext;

        }
        public List<User> GetallUser() {
            var users = _TiendaContext.Users.ToList();
            return users; 
        }

        public User GetUser(string Email, string UserName)
        {
            var user = _TiendaContext.Users.FirstOrDefault(u => u.UserName == UserName || u.Email == Email);
            return user;
        }

        public User GetUserByid (int id)
        {
            var user = _TiendaContext.Users.FirstOrDefault(x=> x.idUser == id);
            return user;
        }
    }
}
