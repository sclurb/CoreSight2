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
        public IActionResult Post([FromBody]ReadingsViewModel model)
        {
            var defaultDate = new DateTime(0001, 01, 01, 00, 00, 00);
            try
            {
                if (ModelState.IsValid)
                {
                    if(model.Date == defaultDate)
                    {
                        model.Date = DateTime.Now.AddHours(3);
                    }

                    var newReading = new Readings()
                    {
                        // Going to be getting data ffrom database now.   values have already been caluculated.
                        //Temp1 = ConvertToFahrenheit(model.Temp1),
                        //Temp2 = ConvertToFahrenheit(model.Temp2),
                        //Temp3 = ConvertToFahrenheit(model.Temp3),
                        //Temp4 = ConvertToFahrenheit(model.Temp4),
                        //Hum1 = ConvertToHumidity(model.Hum1),
                        //Hum2 = ConvertToHumidity(model.Hum2),
                        //Hum3 = ConvertToHumidity(model.Hum3),
                        //Hum4 = ConvertToHumidity(model.Hum4) 
                        Temp1 = model.Temp1,
                        Temp2 = model.Temp2,
                        Temp3 = model.Temp3,
                        Temp4 = model.Temp4,
                        Hum1 = model.Hum1,
                        Hum2 = model.Hum2,
                        Hum3 = model.Hum3,
                        Hum4 = model.Hum4,
                        Date = model.Date
                    };
                    int x;
                    x = _repository.AddReading(newReading);  // yeah i know it's ugly.   I'll fix it next commit.

                    //if (_repository.SaveChanges() > 0)
                    if(x > 0)
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

        private decimal ConvertToFahrenheit(decimal value)
        {
            value = (decimal)((double)value * 1.8) + 32;
            return value;
        }

        private decimal ConvertToHumidity(decimal value)
        {
            if(value == 0)
            {
                return 0;
            }
            else
            {
                double newValue;
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
