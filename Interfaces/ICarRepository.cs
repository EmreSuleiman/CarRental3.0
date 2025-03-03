using CarRental3._0.Models;

namespace CarRental3._0.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAll();
        Task<Car> GetByIdAsync(int id);
        Task<Car> GetByIdAsyncNotracking(int id);
        Task<IEnumerable<Car>> GetCarByCategory(string category);
        bool Add(Car car);
        bool Update(Car car);
        bool Delete(Car car);
        bool Save();
    }
}
