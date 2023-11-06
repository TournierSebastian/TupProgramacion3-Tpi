using ApplicationWeb.Data.Dto;


namespace Service.IService
{
    public interface ISuperAdminService
    {
        DtoUser AddUser(DtoUser user);
        List<DtoUser> GetAllUser();

        string DeleteUserByid(int id);

    }
}
