using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ApplicationWeb.Migrations;

namespace ApplicationWeb.Data.Dto
{
    public class SellOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int idOrder { get; set; }
        public string? PayMethod { get; set; }
       
        public int TotalValue { get; set; }

        //[JsonIgnore]
        //public int QuantityProducts { get; set; }
        //public int idProduct { get; set; }
        //public string Name { get; set; }

        //public int Price { get; set; }

        //public string Descripcion { get; set; }


        public  int  idUser { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }

   
        public bool Validation { get; set; }



    }
}
