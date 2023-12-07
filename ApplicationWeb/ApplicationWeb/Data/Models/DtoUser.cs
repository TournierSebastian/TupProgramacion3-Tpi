using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApplicationWeb.Data.Models
{
    public class DtoUser
    {

            public int idUser { get; set; }
            public string? UserName { get; set; }
            public string? Email { get; set; }
            public string UserType { get; set; }

            public string Password { get; set; }


    }
}
