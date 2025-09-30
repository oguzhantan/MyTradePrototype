using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTradePrototype.Data;
using MyTradePrototype.Models;

namespace MyTradePrototype.Controllers
{
    public class TradeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TradeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trade
        public async Task<IActionResult> Index()
        {
            var trades = await _context.Trades
                                       .OrderByDescending(t => t.TradeDate) // En yeni önce
                                       .ToListAsync();
            return View(trades);
        }

        // GET: Trade/Create
        public IActionResult Create()
        {
            var model = new Trade
            {
                TradeDate = DateTime.Today
            };
            return View();
        }

        // POST: Trade/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trade trade)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Lütfen tüm alanları doğru doldurun.";
                return View(trade);
            }

            try
            {
                _context.Add(trade);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Trade başarıyla oluşturuldu!";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbEx)
            {
                TempData["ErrorMessage"] = $"Veritabanı hatası: {dbEx.Message}";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Bir hata oluştu: {ex.Message}";
            }

            return View(trade);
        }


        // GET: Trade/Details/5
        /*
             Açıklama:

            1 - id parametresi: Kullanıcının görmek istediği trade kaydının ID’si.

            2 - FirstOrDefaultAsync: ID’ye göre ilgili trade’i veri tabanından çeker.

            3 - Eğer trade bulunamazsa NotFound() döner.

            Bulursa, trade objesini Details view’a gönderir.
         */
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var trade = await _context.Trades
                                      .FirstOrDefaultAsync(t => t.Id == id);
            if (trade == null)
                return NotFound();

            return View(trade);
        }

        // GET: Trade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var trade = await _context.Trades.FindAsync(id);
            if (trade == null) return NotFound();

            return View(trade);
        }

        // POST: Trade/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Trade trade)
        {
            if (id != trade.Id) return NotFound();

            if (!ModelState.IsValid)
                return View(trade);

            try
            {
                _context.Update(trade);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Trade başarıyla güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Trades.Any(e => e.Id == trade.Id))
                    return NotFound();
                else
                    throw;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Bir hata oluştu: {ex.Message}");
            }

            return View(trade);
        }



        // GET: Trade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var trade = await _context.Trades
                .FirstOrDefaultAsync(m => m.Id == id);

            if (trade == null) return NotFound();

            return View(trade);
        }

        // POST: Trade/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trade = await _context.Trades.FindAsync(id);
            if (trade != null)
            {
                _context.Trades.Remove(trade);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Trade başarıyla silindi!";
            }
            else
            {
                TempData["ErrorMessage"] = "Trade bulunamadı!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

/*
 Bu kodda şunlar var:

    Index() → Tüm trade kayıtlarını listeler.

    Create() GET → Yeni trade eklemek için formu açar.

    Create() POST → Form submit edildiğinde veriyi kaydeder.

! Şimdilik Edit, Delete, Details eklemiyoruz, önce prototype çalışsın istiyoruz.
 */