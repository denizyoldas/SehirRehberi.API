using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SehirRehberi.API.Data;

namespace SehirRehberi.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class WeatherForecastController : ControllerBase
    {
        private DataContext _context;

        public WeatherForecastController(DataContext context)
        {
            _context = context;

        }


        [HttpGet]
        public async Task<ActionResult> GetValues()
        {
            var value = await _context.Values.ToListAsync();
            return Ok(value);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.id == id);
            return Ok(value);
        }

    }
}
