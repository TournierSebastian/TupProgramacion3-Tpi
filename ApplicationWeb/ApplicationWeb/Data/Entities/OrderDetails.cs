using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApplicationWeb.Data.Entities
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int OrderDetailsID { get; set; }
        public int Productsid { get; set; }


        public int QuantityProducts { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Descripcion { get; set; }

        public int SellOrderId { get; set; }

  

    }
}
