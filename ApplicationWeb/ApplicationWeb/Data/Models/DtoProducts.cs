using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationWeb.Data.Dto
{
    public class DtoProducts
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProducts { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Descripcion { get; set; }

    }
}
