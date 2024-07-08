using Cars_Core.Context;
using Cars_Core.DTOs;
using Cars_Core.IRepos;
using Cars_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars_Infra.Repos
{
    public class CarRepos : ICarRepos
    {
        private readonly CarDBContext _dbContext;
        public CarRepos(CarDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<GetAllCars>> GetAllCarsByRepos()
        {
            var query = from car in _dbContext.Car
                        select new GetAllCars
                        {
                            Id = car.Id,
                            Type = car.Type,
                            Brand = car.Brand,
                            Color = car.Color,
                            Seats= car.Seats,
                            Price= car.Price,
                            Model=car.Model,
                            Fuletype=car.Fuletype,
                            ImagePath=car.ImagePath
                        };
            return await query.ToListAsync();
        }

        public async Task<GetCarDetailsDTO> GetCarDetails(int id)
        {
            var query = from car in _dbContext.Car
                        where car.Id == id
                        select new GetCarDetailsDTO
                        {
                            Id = car.Id,
                            Type = car.Type,
                            Brand = car.Brand,
                            Color = car.Color,
                            Seats = car.Seats,
                            Price = car.Price,
                            Model = car.Model,
                            Fuletype = car.Fuletype,
                            ImagePath = car.ImagePath,
                            IsAvailable=car.IsAvailable,
                            LastCheckupDate=car.LastCheckupDate,
                            IsActive=car.IsActive,
                        };
            return await query.SingleOrDefaultAsync();
        }

        public async Task<Cars> GetCarById(int Id)
        {
            return await _dbContext.Car.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<int> CreateNewCar(Cars input)
        {
            _dbContext.Car.Add(input);
            await _dbContext.SaveChangesAsync();
            return input.Id;
        }

        public async Task UpdateCar<T>(T input)
        {
            _dbContext.Update(input);
            await _dbContext.SaveChangesAsync();
        }
    }
}
