using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreSight2.Data;
using Microsoft.AspNetCore.Mvc;
using CoreSight2.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CoreSight2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly ICoreSightRepository _repository;

        public ChartController(ICoreSightRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Get([FromBody] ChartViewModel dates)
        {
            var result = _repository.GetReadingsByDateRange(dates);

            if(result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.DeleteReadingById(id) > 0)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}