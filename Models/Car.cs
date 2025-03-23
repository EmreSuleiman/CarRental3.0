namespace CarRental3._0.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public CarCategory Category { get; set; } // Use the enum here
        public string Status { get; set; } = "В наличност";
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
