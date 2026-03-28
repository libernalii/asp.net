namespace SubscriptionAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Bday { get; set; }
        public string Email { get; set; }
        public List<Subscription> subscriptions { get; set; }
    }
}
