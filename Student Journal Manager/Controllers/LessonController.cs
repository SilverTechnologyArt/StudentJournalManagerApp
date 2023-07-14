using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Student_Journal_Manager.Models;
using Student_Journal_Manager.Services;

namespace Student_Journal_Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLessons()
        {
            var lessons = await _lessonService.GetAllLessons();
            return Ok(lessons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonById(int id)
        {
            var lesson = await _lessonService.GetLessonById(id);
            if (lesson == null)
                return NotFound();

            return Ok(lesson);
        }

        [HttpPost]
        public async Task<IActionResult> AddLesson([FromBody] LessonDto lessonDto)
        {
            var lesson = new Lesson
            {
                Id = lessonDto.Id,
                LessonName = lessonDto.LessonName,
                Price = lessonDto.Price
            };

            await _lessonService.AddLesson(lesson);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(int id, [FromBody] Lesson lesson)
        {
            if (id != lesson.Id)
                return BadRequest();

            try
            {
                await _lessonService.UpdateLesson(lesson);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            await _lessonService.DeleteLesson(id);
            return Ok();
        }

    [HttpPost("{lessonId}/students/{studentId}")]
    public async Task<IActionResult> AddStudentToLesson(int lessonId, int studentId)
    {
        await _lessonService.AddStudentToLesson(lessonId, studentId);
        return Ok();
    }

    [HttpDelete("{lessonId}/students/{studentId}")]
    public async Task<IActionResult> RemoveStudentFromLesson(int lessonId, int studentId)
    {
        await _lessonService.RemoveStudentFromLesson(lessonId, studentId);
        return Ok();
    }
    }
}
