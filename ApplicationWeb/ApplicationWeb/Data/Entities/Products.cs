
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationWeb.Data.Entities
{
    public class Products
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProducts { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Descripcion { get; set; }

        public int Stock { get; set; }


    }
}
