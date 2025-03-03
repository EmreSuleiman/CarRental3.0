namespace CarRental3._0.Models
{
    public class Booking
    {
        public int BookingId { get; set; } 
        public string
            UserId { get; set; } 
        public AppUser User { get; set; } 
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
        public string BookingStatus { get; set; } = "Pending";
        public string PaymentStatus { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
