namespace ApplicationWeb.Data.ViewModel
{
    public class SellOrderViewMode
    {
        public string? PayMethod { get; set; }


        public List<OrderDetailsViewModel> Products { get; set; }
        public int Userid { get; set; }
    }
}
