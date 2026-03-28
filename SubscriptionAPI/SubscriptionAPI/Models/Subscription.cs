namespace SubscriptionAPI.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
    }
}
