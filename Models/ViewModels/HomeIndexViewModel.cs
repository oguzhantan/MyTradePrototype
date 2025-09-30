namespace MyTradePrototype.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public int TotalTrades { get; set; }
        public decimal TotalValue { get; set; }
        public List<TradeViewModel> RecentTrades { get; set; } = new List<TradeViewModel>();
    }
}
