namespace CarRental3._0.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } // 1-5 stars
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
