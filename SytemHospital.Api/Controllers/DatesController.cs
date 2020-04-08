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
    public class DatesController : ControllerBase
    {
        private readonly SystemContext _context;

        public DatesController(SystemContext context)
        {
            _context = context;
        }

        [HttpPost("[action]")]
        public IActionResult SaveDate([FromBody] DateDto entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var patientObj =_context.Patients
                        .Where(x => x.Id == entityDto.PatientId)
                        .FirstOrDefault();

            var doctortObj = _context.Patients
                .Where(x => x.Id == entityDto.DoctorId)
                .FirstOrDefault();



            Date item = new Date
            {
                PatientId = entityDto.PatientId,
                DoctorId = entityDto.DoctorId,
                DoctorName =doctortObj.Name,
                PatientName =  patientObj.Name,
                OpendDate = entityDto.OpendDate
            };

            _context.Dates.Add(item);
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
        public IActionResult UpdateDate([FromBody] DateDto entityDto)
        {
            if (entityDto.Id <= 0)
            {
                return BadRequest();
            }

            var patientObj = _context.Patients
                        .Where(x => x.Id == entityDto.PatientId)
                        .FirstOrDefault();

            var doctortObj = _context.Patients
                .Where(x => x.Id == entityDto.DoctorId)
                .FirstOrDefault();

            var dateObj = _context.Dates.Where(x => x.Id == entityDto.Id).FirstOrDefault();

            dateObj.PatientName = patientObj.Name;
            dateObj.DoctorName = doctortObj.Name;
            dateObj.OpendDate = entityDto.OpendDate;
            dateObj.PatientId = entityDto.PatientId;
            dateObj.DoctorId = entityDto.DoctorId;

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