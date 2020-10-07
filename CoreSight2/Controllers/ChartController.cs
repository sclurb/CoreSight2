using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreSight2.Data;
using Microsoft.AspNetCore.Mvc;
using CoreSight2.ViewModels;

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
            //var newChartDates = new ChartViewModel()
            //{
            //    To = Convert.ToDateTime(to),
            //    From = Convert.ToDateTime(from)
            //};

            var result = _repository.GetReadingsByDateRange(dates);

            try
            {
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get Readings ..{ex}");
            }
        }
    }
}