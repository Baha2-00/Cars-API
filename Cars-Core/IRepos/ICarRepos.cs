using Cars_Core.DTOs;
using Cars_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars_Core.IRepos
{
    public interface ICarRepos
    {
        Task<int> CreateNewCar(Cars input);
        Task<List<GetAllCars>> GetAllCarsByRepos();
        Task<GetCarDetailsDTO> GetCarDetails(int id);
        Task<Cars> GetCarById(int Id);
        Task UpdateCar<T>(T input);
    }
}
