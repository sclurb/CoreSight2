using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreSight2.Data;
using CoreSight2.Data.Entities;
using CoreSight2.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreSight2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingsController : ControllerBase
    {
        private readonly ICoreSightRepository _repository;

        public ReadingsController(ICoreSightRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Api
        [HttpGet]
        public ActionResult<IEnumerable<Readings>> Get()
        {
            var result = _repository.GetAllReadings();
            try
            {
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get Readings ..{ex}");
            }
        }

        [HttpPost]
       // public async Task<IActionResult> Post([FromBody]ReadingsViewModel model)
        public IActionResult Post([FromBody]ReadingsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newReading = new Readings()
                    {
                        Temp1 = convertToFahrenheit(model.Temp1),    
                        Temp2 = convertToFahrenheit(model.Temp2),
                        Temp3 = convertToFahrenheit(model.Temp3),
                        Temp4 = convertToFahrenheit(model.Temp4),
                        Hum1 = convertToHumidity(model.Hum1),
                        Hum2 = convertToHumidity(model.Hum2),
                        Hum3 = convertToHumidity(model.Hum3),
                        Hum4 = convertToHumidity(model.Hum4),
                        Date = DateTime.Now
                    };

                    _repository.AddReading(newReading);

                    if (_repository.SaveAll())
                    {
                        return Created($"/api/readings/{newReading.Id}", newReading);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
               // _logger.LogError($"Failed to save new Order {ex}");
            }
            return BadRequest($"Failed to save new Order ");
        }

        private decimal convertToFahrenheit(decimal value)
        {
            value = (decimal)((double)value * 1.8) + 32;
            return value;
        }

        private decimal convertToHumidity(decimal value)
        {
            if(value == 0)
            {
                return 0;
            }
            else
            {
                double newValue = 0;
                newValue = ((double)value / 9.24);
                newValue = 90 - ((2.7 - newValue) / .03);
                newValue = Math.Round(newValue, 2);
                return (decimal)newValue;
            }
        }

        // GET: api/Api/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }



        // PUT: api/Api/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
