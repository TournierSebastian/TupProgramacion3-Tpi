using ApplicationWeb.Data.Entities;

namespace ApplicationWeb.Data.Models
{
    public class DtoSellOrderGet
    {

        public int idOrder { get; set; }
        public string? PayMethod { get; set; }
        public int TotalValue { get; set; }

        public string? UserName { get; set; }
        public string? Email { get; set; }


        public ICollection<OrderDetails> OrdenDetails { get; set; }
    }
}
