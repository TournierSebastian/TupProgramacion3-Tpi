using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;
using ApplicationWeb.Encrypt;
using Service.IService;


namespace ApplicationWeb.Service.Implements
{
    public class AuthService : IAuthService
    {
        private readonly TiendaContext _context;

        public AuthService(TiendaContext context)
        {
            _context = context;
        }
        public BaseResponse ValidateUser(string email, string password)
        {

            BaseResponse response = new BaseResponse();
            User? userForLogin = _context.Users.SingleOrDefault(u => u.Email == email);
            if (userForLogin != null)
            {
                if (userForLogin.Password == password.Hash())
                {
                    response.Result = true;
                    response.Message = "loging Succesfull";
                }
                else
                {
                    response.Result = false;
                    response.Message = "wrong password";
                }

            }
            else
            {
                response.Result = false;
                response.Message = "wrong email";
            }
            return response;
        }

        public User? GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

    }

}


