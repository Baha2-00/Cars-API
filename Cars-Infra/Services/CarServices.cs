using Cars_Core.DTOs;
using Cars_Core.IRepos;
using Cars_Core.Iservices;
using Cars_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars_Infra.Services
{
    public class CarServices : ICarServices
    {
        private readonly ICarRepos _carRepos;
        public CarServices(ICarRepos carRepos)
        {
            _carRepos = carRepos;
        }

        public async Task CreateNewCar(CreateCarDTO input)
        {
            Cars car = new Cars();
            car.Type=input.Type;
            car.Brand=input.Brand;
            car.Color=input.Color;
            car.Seats=input.Seats;
            car.Price=input.Price;
            car.Model=input.Model;
            car.Description=input.Description;
            car.Fuletype=input.Fuletype;
            car.Platenumber=input.Platenumber;
            car.ImagePath=input.ImagePath;
            car.CreationDate=DateTime.Now;
            car.LastCheckupDate=DateTime.Now;
            car.IsActive = true;
            car.IsAvailable = true;

            var id = await _carRepos.CreateNewCar(car);
        }

        public async Task<List<GetAllCars>> GetAllCars()
        {
            return await _carRepos.GetAllCarsByRepos();
        }
        public async Task<GetCarDetailsDTO> GetCarDetails(int id)
        {
            var car=await _carRepos.GetCarById(id);
            if (car != null)
            {
                return await _carRepos.GetCarDetails(id);
            }
            else
            {
                throw new Exception("Car Dose not Exisit");
            }
        }

        public async Task UpdateCar(UpdateCarDTO input)
        {
            //check if exisit 
            var car = await _carRepos.GetCarById(input.Id);
            if (car != null)
            {
                if (input.Price != null && !input.Price.Equals(""))
                {
                    car.Price = input.Price;
                }
                if (!string.IsNullOrEmpty(input.Description))
                {
                    car.Description = input.Description;
                }
                if (!string.IsNullOrEmpty(input.ImagePath))
                {
                    car.ImagePath = input.ImagePath;
                }
                await _carRepos.UpdateCar(car);
            }
            else
            {
                throw new Exception("Blog Dose not Exisit");
            }
        }

        public async Task UpdateCarActivation(int Id, bool value)
        {
            var car = await _carRepos.GetCarById(Id);
            if (car != null)
            {
                car.IsActive = value;
                await _carRepos.UpdateCar(car);
            }
            else
            {
                throw new Exception("Blog Dose not Exisit");
            }
        }

        public async Task UpdateCarAvailability(int Id, bool value)
        {
            var car = await _carRepos.GetCarById(Id);
            if (car != null)
            {
                car.IsAvailable = value;
                await _carRepos.UpdateCar(car);
            }
            else
            {
                throw new Exception("Blog Dose not Exisit");
            }
        }
    }
}
