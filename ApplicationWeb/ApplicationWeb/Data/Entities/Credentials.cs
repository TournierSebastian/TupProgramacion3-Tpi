
using System.ComponentModel.DataAnnotations;

namespace ApplicationWeb.Data.Entities
{
    public class Credentials
    {
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
