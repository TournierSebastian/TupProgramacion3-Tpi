﻿namespace ApplicationWeb.Data.Models
{
    public class ProductsDto
    {
        public int idProducts { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Descripcion { get; set; }

        public int Stock { get; set; }
    }
}
