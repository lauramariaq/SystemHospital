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
    public class PatientController : ControllerBase
    {
        private readonly SystemContext _context;

        public PatientController(SystemContext context)
        {
            _context = context;
        }


        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var patient = _context.Patients.Where(x => !x.IsDeleted).ToList();

            if (patient is null)
                return NotFound();

            return Ok(patient);

        }
        [HttpPost("[action]")]
        public IActionResult SavePatient([FromBody] PatientDto entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Patient item = new Patient 
            {
                Name = entityDto.Name,
                Cedula = entityDto.Cedula,
                Insurance = entityDto.Insurance

            };
            if (item.Insurance)
            {
                item.InsuranceName = entityDto.InsuranceName;
            }

            _context.Patients.Add(item);

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
        public IActionResult EditPatient([FromBody] PatientDto entityDto)
        {
            if (entityDto.Id <= 0)
            {
                return BadRequest();
            }

            var patientObj = _context.Patients.Where(x => x.Id == entityDto.Id).FirstOrDefault();

            patientObj.Name = entityDto.Name;
            patientObj.Cedula = entityDto.Cedula;
            patientObj.Insurance = entityDto.Insurance;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return Ok(patientObj);

        }
        [HttpPut("[action]/{id}")]
        public IActionResult DeletePatient(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var patientObj = _context.Patients.Where(x => x.Id == id).FirstOrDefault();

            patientObj.IsDeleted = true;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return Ok(patientObj);

        }
    }
}
