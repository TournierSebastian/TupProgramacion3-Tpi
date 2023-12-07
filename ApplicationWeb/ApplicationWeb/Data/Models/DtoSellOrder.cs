using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;

    namespace ApplicationWeb.Data.Models
    {
        public class DtoSellOrder
        {


            public int idOrder { get; set; }
            public string? PayMethod { get; set; }
            public int TotalValue { get; set; }


            public int idUser { get; set; }
            public string? UserName { get; set; }
            public string? Email { get; set; }
            public bool Validation { get; set; }

        public ICollection<OrderDetails> OrdenDetails { get; set; }
    }
    }
