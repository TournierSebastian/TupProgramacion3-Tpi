using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.ViewModel;
using ApplicationWeb.Encrypt;

using ApplicationWeb.Service.Interfaces;
using AutoMapper;


namespace ApplicationWeb.Service.Implements
{
    public class SuperAdminService : ISuperAdminService
    {
        private readonly TiendaContext _TiendaContext;

        public SuperAdminService(TiendaContext TiendaContext)
        {
    
            _TiendaContext = TiendaContext;
     

        }

        public DtoUser AddUser(UserViewModel user)
        {
            
            var existingUser = _TiendaContext.DtoUsers
            .FirstOrDefault(u => u.UserName == user.UserName || u.Email == user.Email);
          
            if (user.Email.Contains("@") && user.Email.EndsWith(".com")
              && user.UserName != "" && user.Password != "" && existingUser == null && user.UserType == "Customer" || user.UserType == "Admin" || user.UserType == "SuperAdmin")
              
            {

                var Users = new DtoUser
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password.Hash(),
                    UserType = user.UserType,
                };
                _TiendaContext.DtoUsers.Add(Users);
                _TiendaContext.SaveChanges();
                return Users;
            }
            return null;
        }

        public List<DtoUser> GetAllUser()
        {
            List<DtoUser> users = _TiendaContext.DtoUsers.Select(user => new DtoUser
            {
                idUser = user.idUser,
                UserName = user.UserName,
                Email = user.Email,
                UserType = user.UserType,
                Password = string.Empty,
             }).ToList();

            return users;

        }


        public string DeleteUserByid(int id)
        {
            var userid = _TiendaContext.DtoUsers.FirstOrDefault(x => x.idUser == id);
    
            if (userid == null)
            {
                return "User not found";
            }
            var sellOrders = _TiendaContext.DtoSellOrders.Where(x => x.idUser == id).ToList();
           
                foreach (var order in sellOrders)
                {
                    order.Validation = false;
                }

  

            _TiendaContext.Remove(userid);
            _TiendaContext.SaveChanges();
            return "Delete User";
        }
    }
}
