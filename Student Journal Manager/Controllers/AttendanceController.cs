using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Student_Journal_Manager.Models;
using Student_Journal_Manager.Services;

namespace Student_Journal_Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAttendances()
        {
            var attendances = await _attendanceService.GetAllAttendances();
            return Ok(attendances);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendanceById(int id)
        {
            var attendance = await _attendanceService.GetAttendanceById(id);
            if (attendance == null)
                return NotFound();

            return Ok(attendance);
        }

        [HttpPost]
        public async Task<IActionResult> AddAttendance([FromBody] Attendance attendance)
        {
            await _attendanceService.AddAttendance(attendance);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendance(int id, [FromBody] Attendance attendance)
        {
            if (id != attendance.Id)
                return BadRequest();

            try
            {
                await _attendanceService.UpdateAttendance(attendance);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            await _attendanceService.DeleteAttendance(id);
            return Ok();
        }
    }
}