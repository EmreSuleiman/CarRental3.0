namespace CarRental3._0.Models
{
    public class Rental
    {
        public int RentalId { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.UtcNow;
        public DateTime ReturnDate { get; set; }
        public decimal TotalCost { get; set; }

        // Foreign keys and navigation properties
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
