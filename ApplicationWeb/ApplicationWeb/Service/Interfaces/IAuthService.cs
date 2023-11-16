using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;


namespace Service.IService
{
    public interface IAuthService
    {
        public DtoUser? GetByEmail(string userEmail);
      
        
        public BaseResponse ValidateUser(string email, string password);
    }
}
