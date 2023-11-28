using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApplicationWeb.Data.Entities
{
    public class SellOrder
    {
        public int idOrder { get; set; }
        public string? PayMethod { get; set; }

        public int TotalValue { get; set; }

        public int QuantityProducts { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public string Descripcion { get; set; }

        public string? UserName { get; set; }
        public string? Email { get; set; }
    }
}


