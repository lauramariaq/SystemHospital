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
    public class RoomsController : ControllerBase
    {
        private readonly SystemContext _context;

        public RoomsController(SystemContext context)
        {
            _context = context;
        }


        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var rooms = _context.Rooms.Where(x => !x.IsDeleted).ToList();

            var list = rooms;
            if (rooms is null)
                return NotFound();

            return Ok(list);

        }
        [HttpPost("[action]")]
        public IActionResult SaveRoom([FromBody] RoomDto entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Room item = new Room
            {
                Number = entityDto.Number,
                Type = entityDto.Type,
                Price = entityDto.Price
            };

            _context.Rooms.Add(item);

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
        public IActionResult EditRoom([FromBody] RoomDto entityDto)
        {
            if (entityDto.Id <= 0)
            {
                return BadRequest();
            }

            var roomObj = _context.Rooms.Where(x => x.Id == entityDto.Id).FirstOrDefault();

            roomObj.Number = entityDto.Number;
            roomObj.Type = entityDto.Type;
            roomObj.Price = entityDto.Price;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return Ok(roomObj);

        }

        [HttpPut("[action]/{id}")]
        public IActionResult DeleteRoom(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var roomObj = _context.Rooms.Where(x => x.Id == id).FirstOrDefault();

            roomObj.IsDeleted = true;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return Ok(roomObj);

        }
    }
}
