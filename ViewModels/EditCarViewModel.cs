using CarRental3._0.Models;
using System.ComponentModel.DataAnnotations;

namespace CarRental3._0.ViewModels
{
    public class EditCarViewModel
    {
        public int CarId { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal DailyRate { get; set; }

        [Required]
        public CarCategory Category { get; set; }

        [Required]
        public string Status { get; set; }

        public string? Image { get; set; }
    }
}
