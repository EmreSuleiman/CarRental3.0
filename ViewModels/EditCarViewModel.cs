namespace CarRental3._0.ViewModels
{
    public class EditCarViewModel
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public string Category { get; set; } = "Икономични";
        public string Status { get; set; } = "В наличност";
        public string? Image { get; set; }
    }
}
