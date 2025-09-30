    using MyTradePrototype.Models.Validation;
    using System.ComponentModel.DataAnnotations;

    namespace MyTradePrototype.Models
    {
        public class Trade
        {
            [Key]
            public int Id { get; set; }                  // Trade ID (Primary Key)

            [Required(ErrorMessage = "Product Name is required.")]
            [StringLength(100, ErrorMessage = "Product Name cannot exceed 100 characters.")]
            public string ProductName { get; set; }      // Ürün veya malzeme adı

            [Required(ErrorMessage = "Quantity is required.")]
            [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
            public int Quantity { get; set; }            // Miktar

            [Required(ErrorMessage = "Price is required.")]
            [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
            public decimal Price { get; set; }           // Birim fiyat

            [Required(ErrorMessage = "Buyer is required.")]
            [StringLength(100, ErrorMessage = "Buyer name cannot exceed 100 characters.")]
            public string Buyer { get; set; }            // Alıcı

            [Required(ErrorMessage = "Seller is required.")]
            [StringLength(100, ErrorMessage = "Seller name cannot exceed 100 characters.")]
            public string Seller { get; set; }           // Satıcı

            [DataType(DataType.Date)]
            [Display(Name = "Trade Date")]
            [Required(ErrorMessage = "Trade Date is required.")]
            [TradeDateValidation(ErrorMessage = "Trade date cannot be in the past.")]
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