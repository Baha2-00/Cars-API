using Cars_Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars_Core.Iservices
{
    public interface ICarServices
    {
        Task CreateNewCar(CreateCarDTO input);
        Task<List<GetAllCars>> GetAllCars();
        Task<GetCarDetailsDTO> GetCarDetails(int id);
        Task UpdateCarAvailability(int Id, bool value);
        Task UpdateCarActivation(int Id, bool value);
        Task UpdateCar(UpdateCarDTO input);
    }
}
