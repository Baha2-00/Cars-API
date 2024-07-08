using Cars_Core.DTOs;
using Cars_Core.Iservices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Cars_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarServices _car;

        public CarController(ICarServices Carservice)
        {
            _car = Carservice;
        }

        #region Get

        /// <summary>
        /// Retrieves all The Cars In My Db
        /// </summary>
        /// <response code="200">Returns the available Cars</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCars()
        {
            try
            {
                Log.Information("GetAllCars Was Called");
                Log.Information("GetAllCars Was Returned");
                return StatusCode(200, await _car.GetAllCars());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves One Car In My Db
        /// </summary>
        /// <response code="200">Returns the available Car</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetCarByID([FromRoute] int Id)
        {
            try
            {
                Log.Information("Get car Was Called");
                Log.Information("Get car Was Returned");
                var obj = await _car.GetCarDetails(Id);
                return StatusCode(200, obj);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        #endregion


        #region Create

        /// <summary>
        /// Retrieves all The Cars In My Db
        /// </summary>
        /// <response code="200">Returns the available Cars</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateNewCar([FromBody] CreateCarDTO dt)
        {
            if (dt == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _car.CreateNewCar(dt);
                    return StatusCode(201, "New Account Has Been Created");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        #endregion


        #region Update

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCar([FromBody] UpdateCarDTO input)
        {
            if (input == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _car.UpdateCar(input);
                    return StatusCode(200, "Car Has Been Update");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCarAvailability([FromQuery] int Id, [FromQuery] bool value)
        {
            if (Id == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _car.UpdateCarAvailability(Id, value);
                    return StatusCode(200, "Car Has Been Update");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateBlogAactivation([FromQuery] int Id, [FromQuery] bool value)
        {
            if (Id == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _car.UpdateCarActivation(Id, value);
                    return StatusCode(200, "Car Has Been Update");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        #endregion
    }
}


  