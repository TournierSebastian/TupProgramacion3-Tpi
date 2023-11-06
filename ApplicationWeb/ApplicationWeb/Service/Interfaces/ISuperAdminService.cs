using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.ViewModel;

namespace Service.IService
{
    public interface ISuperAdminService
    {
        DtoUser AddUser(UserViewModel user);
        List<DtoUser> GetAllUser();
        string DeleteUserByid(int id);

    }
}
