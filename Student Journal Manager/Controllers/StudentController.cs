using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Student_Journal_Manager.Models;
using Student_Journal_Manager.Services;

namespace Student_Journal_Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
        {
            var student = new Student
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName
            };

            await _studentService.AddStudent(student);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            if (id != student.Id)
                return BadRequest();

            try
            {
                await _studentService.UpdateStudent(student);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteStudent(id);
            return Ok();
        }
    }
}
