using ApplicationWeb.Data;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationWeb.Service.Implements
{
    public class AuthService : IAuthService
    {
        private readonly TiendaContext _context;

        public AuthService(TiendaContext context)
        {
            _context = context;
        }
        public Tuple<bool, DtoUser?> ValidateUser(string email, string password)
        {
            DtoUser? userForLogin = _context.DtoUsers.SingleOrDefault(u => u.Email == email);
            if (userForLogin != null)
            {
                if (userForLogin.Password == password)
                    return new Tuple<bool, DtoUser?>(true, userForLogin);
                return new Tuple<bool, DtoUser?>(false, userForLogin);
            }
            return new Tuple<bool, DtoUser?>(false, null);
        }

        public DtoUser? GetByEmail(string userEmail)
        {
            return _context.DtoUsers.SingleOrDefault(u => u.Email == userEmail);
        }

        public void DeleteUser(DtoUser userToDeleteDto)
        {
            if (userToDeleteDto == null)
            {
                throw new ArgumentNullException(nameof(userToDeleteDto));
            }
            _context.Remove(userToDeleteDto);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }

}


