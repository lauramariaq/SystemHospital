using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SytemHospital.Bi.Dto;
using SytemHospital.Model.Entities;
using SytemHospital.Model.SystemContex;

namespace SytemHospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AltasController : ControllerBase
    {
        private readonly SystemContext _context;

        public AltasController(SystemContext context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var altas = _context.Altas.ToList();

            if (altas is null)
                return NotFound();

            return Ok(altas);
        }
        [HttpPost("[action]")]
        public IActionResult SaveAlta([FromBody] AltaDto entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
           var roomObj = _context.Rooms.Where(x => x.Type == entityDto.TypeRoom).FirstOrDefault();

            var totalPrecio = roomObj.Price * entityDto.TotalPrice;

            Alta item = new Alta
            {
                IncomeId = entityDto.IncomeId,
                PatientName = entityDto.PatientName,
                TypeRoom = entityDto.TypeRoom,
                DateEnd = entityDto.DateEnd,
                TotalPrice = totalPrecio
            };

            _context.Altas.Add(item);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(item);
        }
    }
}