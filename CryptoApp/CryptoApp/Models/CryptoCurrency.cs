namespace CryptoApp.Models
{
    public class CryptoCurrency
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }

        public decimal Change1h { get; set; }
        public decimal Change24h { get; set; }
        public decimal Change7d { get; set; }

        public decimal MarketCap { get; set; }
        public decimal Volume24h { get; set; }
        public decimal Supply { get; set; }
    }
}