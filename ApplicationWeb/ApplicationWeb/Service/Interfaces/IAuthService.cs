using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;


namespace Service.IService
{
    public interface IAuthService
    {
        public User? GetByEmail(string userEmail);
      
        
        public BaseResponse ValidateUser(string email, string password);
    }
}
