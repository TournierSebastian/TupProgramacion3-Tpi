using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ApplicationWeb.Data.Entities;

namespace ApplicationWeb.Data.Dto
{
    public class DtoSellOrder
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idOrder { get; set; }
        public string? PayMethod { get; set; }

        public int TotalValue { get; set; }

        
    }
}
