
using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;
using Service.IService;


namespace ApplicationWeb.Service.Implements
{
    public class SuperAdminService : ISuperAdminService
    {
        private readonly TiendaContext _TiendaContext;

        public SuperAdminService(TiendaContext TiendaContext)
        {
            _TiendaContext = TiendaContext;
        }

        public DtoUser AddUser(DtoUser user)
        {

            var existingUser = _TiendaContext.DtoUsers
            .FirstOrDefault(u => u.UserName == user.UserName || u.Email == user.Email);
          
            if (user.Email.Contains("@") && user.Email.EndsWith(".com")
              && user.UserName != "" && user.Password != "" && existingUser == null)
            {

                _TiendaContext.DtoUsers.Add(user);
                _TiendaContext.SaveChanges();
                return user;
            }
            return null;
        }

        public List<DtoUser> GetAllUser()
        {
            var user = _TiendaContext.DtoUsers.ToList();

            return user;

        }


        public string DeleteUserByid(int id)
        {
            var userid = _TiendaContext.DtoUsers.FirstOrDefault(x => x.idUser == id);

            if (userid == null)
            {
                return "User not found";
            }

            _TiendaContext.Remove(userid);
            _TiendaContext.SaveChanges();
            return "Delete User";
        }
    }
}
