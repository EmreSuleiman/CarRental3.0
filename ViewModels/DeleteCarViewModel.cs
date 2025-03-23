using CarRental3._0.Models;

namespace CarRental3._0.ViewModels
{
    public class DeleteCarViewModel
    {
        public int CarId { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public CarCategory Category { get; set; } // Use the enum here
        public string Status { get; set; } = "В наличност";
        public string? Image { get; set; }
    }
}
