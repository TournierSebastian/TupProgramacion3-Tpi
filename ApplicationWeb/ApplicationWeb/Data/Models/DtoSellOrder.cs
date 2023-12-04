using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ApplicationWeb.Data.Dto;

    namespace ApplicationWeb.Data.Models
    {
        public class DtoSellOrder
        {


            public int idOrder { get; set; }
            public string? PayMethod { get; set; }
            public int TotalValue { get; set; }




            public string? UserName { get; set; }
            public string? Email { get; set; }

            public List<DtoOrderDetail> OrderDetails { get; set; }
    }
    }
