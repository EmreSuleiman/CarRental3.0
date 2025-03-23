using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental3._0.Models
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
        public bool HasBooked { get; set; }
        public string? Role { get; set; }
        public bool IsBlacklisted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
