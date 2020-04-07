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
    public class DoctorsController : ControllerBase
    {
        private readonly SystemContext _context;

        public DoctorsController(SystemContext context)
        {
            _context = context;
        }


        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var doctors = _context.Doctors.Where(x => !x.IsDeleted).ToList();

            if (doctors is null)
                return NotFound();

            return Ok(doctors);

        }
        [HttpPost("[action]")]
        public IActionResult SaveDoctor([FromBody] DoctorDto entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Doctor item = new Doctor
            {
                Name = entityDto.Name,
                Exequator = entityDto.Exequator,
                Specialty = entityDto.Specialty
            };

            _context.Doctors.Add(item);

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
        public IActionResult EditDoctor([FromBody] DoctorDto entityDto)
        {
            if (entityDto.Id <= 0)
            {
                return BadRequest();
            }

            var doctorObj = _context.Doctors.Where(x => x.Id == entityDto.Id).FirstOrDefault();

            doctorObj.Name = entityDto.Name;
            doctorObj.Specialty = entityDto.Specialty;
            doctorObj.Exequator = entityDto.Exequator;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return Ok(doctorObj);

        }
        [HttpPut("[action]/{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var doctorObj = _context.Doctors.Where(x => x.Id == id).FirstOrDefault();

            doctorObj.IsDeleted = true;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return Ok(doctorObj);

        }
    }
}