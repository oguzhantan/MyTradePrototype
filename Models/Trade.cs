using System.ComponentModel.DataAnnotations;

namespace MyTradePrototype.Models
{
    public class Trade
    {
        [Key]
        public int Id { get; set; }                  // Trade ID (Primary Key)

        [Required]
        public string ProductName { get; set; }      // Ürün veya malzeme adı

        [Required]
        public int Quantity { get; set; }            // Miktar

        [Required]
        public decimal Price { get; set; }           // Birim fiyat

        [Required]
        public string Buyer { get; set; }            // Alıcı

        [Required]
        public string Seller { get; set; }           // Satıcı

        public DateTime TradeDate { get; set; } = DateTime.Now;  // İşlem tarihi
    }
}

/*
 * Trade Modeli Açıklaması:
 *
 * Id           → EF Core tarafından otomatik birincil anahtar olarak kullanılır.
 * ProductName  → Ürün veya malzeme adı.
 * Quantity     → İşlem miktarı.
 * Price        → Birim fiyat.
 * Buyer        → Alıcı bilgisi.
 * Seller       → Satıcı bilgisi.
 * TradeDate    → İşlem tarihi (varsayılan olarak oluşturulma zamanı atanır).
 *
 * Not:
 * Bu model, prototype için temel trade bilgilerini içerir.
 * İleride ihtiyaç duyulursa Currency, Status, PaymentType gibi alanlar eklenebilir.
 */