using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTradePrototype.Data;
using MyTradePrototype.Models;
using MyTradePrototype.Models.ViewModels;

namespace MyTradePrototype.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var totalTrades = await _context.Trades.CountAsync();

            var totalValue = await _context.Trades
                .Select(t => t.Price * t.Quantity)
                .SumAsync();

            var recentTrades = await _context.Trades
                .OrderByDescending(t => t.TradeDate)
                .Take(5)
                .Select(t => new TradeViewModel
                {
                    Id = t.Id,
                    ProductName = t.ProductName,
                    Quantity = t.Quantity,
                    Price = t.Price,
                    Buyer = t.Buyer,
                    Seller = t.Seller,
                    TradeDate = t.TradeDate
                })
                .ToListAsync();

            var model = new HomeIndexViewModel
            {
                TotalTrades = totalTrades,
                TotalValue = totalValue,
                RecentTrades = recentTrades
            };

            return View(model);
        }
    }
}
