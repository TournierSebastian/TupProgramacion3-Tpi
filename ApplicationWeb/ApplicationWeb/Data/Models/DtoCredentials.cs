
using System.ComponentModel.DataAnnotations;

namespace ApplicationWeb.Data.Dto
{
    public class DtoCredentials
    {
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
