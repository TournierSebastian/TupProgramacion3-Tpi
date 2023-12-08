using ApplicationWeb.Data;
using ApplicationWeb.Data.Entities;
using ApplicationWeb.Data.Models;
using ApplicationWeb.Data.Repository.Interfaces;
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
        private readonly IUserRepository _UserRepository;
        public UserService(IMapper mapper,TiendaContext TiendaContext, IUserRepository userRepository)
        {
    
            _TiendaContext = TiendaContext;
            _mapper = mapper;
            _UserRepository = userRepository;

        }


        public List<UserGetDto> GetAllUser()
        {
            List<UserGetDto> users = _UserRepository.GetallUser().Select(user => new UserGetDto
            {
                idUser = user.idUser,
                UserName = user.UserName,
                Email = user.Email,
                UserType = user.UserType,
             }).ToList();   
      
           

            return users;

        }

        public UserDto AddUser(UserViewModel user)
        {

            var existingUser = _UserRepository.GetUser(user.Email, user.UserName);

            if (user.Email.Contains("@") && user.Email.EndsWith(".com")
              && user.UserName != "" && user.Password != "" && existingUser == null && user.UserType == "Customer" || user.UserType == "Admin" || user.UserType == "SuperAdmin")

            {
                User Users;
                Users = _mapper.Map<User>(user);
                Users.Password = user.Password.Hash();
                _TiendaContext.Users.Add(Users);
                _TiendaContext.SaveChanges();
                return _mapper.Map<UserDto>(Users);
            }
            return null;
        }

        public string DeleteUserByid(int id)
        {
            var userid = _UserRepository.GetUserByid(id);
    
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
