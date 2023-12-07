using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.ViewModel;
using ApplicationWeb.Encrypt;

using ApplicationWeb.Service.Interfaces;
using AutoMapper;


namespace ApplicationWeb.Service.Implements
{
    public class UserService : IUserService
    {
        private readonly TiendaContext _TiendaContext;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper,TiendaContext TiendaContext)
        {
    
            _TiendaContext = TiendaContext;
            _mapper = mapper;

        }


        public List<DtoUserGet> GetAllUser()
        {
            List<DtoUserGet> users = _TiendaContext.Users.Select(user => new DtoUserGet
            {
                idUser = user.idUser,
                UserName = user.UserName,
                Email = user.Email,
                UserType = user.UserType,
             }).ToList();   

            return users;

        }

        public DtoUser AddUser(UserViewModel user)
        {

            var existingUser = _TiendaContext.Users
            .FirstOrDefault(u => u.UserName == user.UserName || u.Email == user.Email);

            if (user.Email.Contains("@") && user.Email.EndsWith(".com")
              && user.UserName != "" && user.Password != "" && existingUser == null && user.UserType == "Customer" || user.UserType == "Admin" || user.UserType == "SuperAdmin")

            {

                //var Users = new User
                //{
                //    UserName = user.UserName,
                //    Email = user.Email,
                //    Password = user.Password.Hash(),
                //    UserType = user.UserType,
                //};

                User Users;
                Users = _mapper.Map<User>(user);
                Users.Password = user.Password.Hash();
                _TiendaContext.Users.Add(Users);
                _TiendaContext.SaveChanges();
                return _mapper.Map<DtoUser>(Users);
            }
            return null;
        }

        public string DeleteUserByid(int id)
        {
            var userid = _TiendaContext.Users.FirstOrDefault(x => x.idUser == id);
    
            if (userid == null)
            {
                return "User not found";
            }
            var sellOrders = _TiendaContext.SellOrders.Where(x => x.idUser == id).ToList();
           
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
