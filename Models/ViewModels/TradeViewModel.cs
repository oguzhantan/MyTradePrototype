namespace MyTradePrototype.Models
{
    public class TradeViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Buyer { get; set; } = string.Empty;
        public string Seller { get; set; } = string.Empty;
        public DateTime? TradeDate { get; set; } // nullable
    }

}
