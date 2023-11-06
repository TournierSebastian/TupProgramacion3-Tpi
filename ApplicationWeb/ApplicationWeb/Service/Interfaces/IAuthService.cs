using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IAuthService
    {
        public DtoUser? GetByEmail(string userEmail);
        Task<bool> SaveChangesAsync();
        void DeleteUser(DtoUser userToDeleteDto);
        Tuple<bool, DtoUser?> ValidateUser(string? email, string? password);
    }
}
