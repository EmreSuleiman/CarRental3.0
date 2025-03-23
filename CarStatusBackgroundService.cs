using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using CarRental3._0.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

public class CarStatusBackgroundService : BackgroundService
{
    private readonly ILogger<CarStatusBackgroundService> _logger;
    private readonly IServiceProvider _services;

    public CarStatusBackgroundService(ILogger<CarStatusBackgroundService> logger, IServiceProvider services)
    {
        _logger = logger;
        _services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Car Status Background Service is starting.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                // Create a new scope for each iteration
                using (var scope = _services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    // Find cars that are rented and have passed their return date
                    var overdueRentals = await context.Rentals
                        .Include(r => r.Car) // Include the Car entity
                        .Where(r => r.ReturnDate < DateTime.UtcNow && r.Car.Status == "Rented")
                        .ToListAsync(stoppingToken);

                    foreach (var rental in overdueRentals)
                    {
                        // Update the car status to "В наличност"
                        rental.Car.Status = "В наличност";
                        context.Cars.Update(rental.Car);
                        _logger.LogInformation($"Updated car {rental.Car.CarId} status to 'В наличност'.");
                    }

                    await context.SaveChangesAsync(stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating car statuses.");
            }

            // Wait for 1 hour before checking again
            await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
        }

        _logger.LogInformation("Car Status Background Service is stopping.");
    }
}