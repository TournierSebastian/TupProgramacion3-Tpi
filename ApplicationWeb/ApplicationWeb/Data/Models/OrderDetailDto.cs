namespace ApplicationWeb.Data.Models
{
    public class OrderDetailDto
    {
        public int Productsid { get; set; }
        public int QuantityProducts { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Descripcion { get; set; }
    }
}
