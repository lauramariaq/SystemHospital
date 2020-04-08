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
    public class IncomesController : ControllerBase
    {
        private readonly SystemContext _context;

        public IncomesController(SystemContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var incomes = _context.Incomes.ToList();

            if (incomes is null)
                return NotFound();

            return Ok(incomes);
        }
        [HttpPost("[action]")]
        public IActionResult SaveIncome([FromBody] IncomeDto entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var patientObj = _context.Patients
                        .Where(x => x.Id == entityDto.PatientId)
                        .FirstOrDefault();

            var roomObj = _context.Rooms
                .Where(x => x.Id == entityDto.RoomId)
                .FirstOrDefault();


            Income item = new Income
            {
                PatientId = entityDto.PatientId,
                RoomId = entityDto.RoomId,
                TypeRoom = roomObj.Type,
                PatientName = patientObj.Name,
                IncomeDate = entityDto.IncomeDate
            };

            _context.Incomes.Add(item);
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
        [HttpPut("[action]")]
        public IActionResult UpdateDate([FromBody] IncomeDto entityDto)
        {
            if (entityDto.Id <= 0)
            {
                return BadRequest();
            }

            var patientObj = _context.Patients
                        .Where(x => x.Id == entityDto.PatientId)
                        .FirstOrDefault();

            var roomObj = _context.Patients
                .Where(x => x.Id == entityDto.RoomId)
                .FirstOrDefault();

            var dateObj = _context.Incomes.Where(x => x.Id == entityDto.Id).FirstOrDefault();

            dateObj.PatientName = patientObj.Name;
            dateObj.TypeRoom = roomObj.Name;
            dateObj.IncomeDate = entityDto.IncomeDate;
            dateObj.PatientId = entityDto.PatientId;
            dateObj.RoomId = entityDto.RoomId;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return Ok(dateObj);

        }
    }
}