using System.Collections.Generic;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Student_Journal_Manager.Exceptions;
using Student_Journal_Manager.Models;
using Student_Journal_Manager.Repositories;

namespace Student_Journal_Manager.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IStudentRepository _studentRepository;

        public LessonService(ILessonRepository lessonRepository, IStudentRepository studentRepository)
        {
            _lessonRepository = lessonRepository;
            _studentRepository = studentRepository;
        }

        public async Task<List<Lesson>> GetAllLessons()
        {
            return await _lessonRepository.GetAllLessons();
        }

        public async Task<Lesson> GetLessonById(int id)
        {
            return await _lessonRepository.GetLessonById(id);
        }

        public async Task AddLesson(Lesson lesson)
        {
            await _lessonRepository.AddLesson(lesson);
        }

        public async Task UpdateLesson(Lesson lesson)
        {
            await _lessonRepository.UpdateLesson(lesson);
        }

        public async Task DeleteLesson(int id)
        {
            await _lessonRepository.DeleteLesson(id);
        }

        public async Task RemoveStudentFromLesson(int lessonId, int studentId)
        {
            var lesson = await _lessonRepository.GetLessonById(lessonId);
            if (lesson == null)
            {
                throw new NotFoundException("Lesson not found");
            }

            if (lesson.LessonStudents != null)
            {
                var lessonStudent = lesson.LessonStudents.FirstOrDefault(ls => ls.StudentId == studentId);
                if (lessonStudent == null)
                {
                    throw new NotFoundException("Student not found in the lesson");
                }

                lesson.LessonStudents.Remove(lessonStudent);
            }

            await _lessonRepository.UpdateLesson(lesson);
        }

        public async Task AddStudentToLesson(int lessonId, int studentId)
        {
            var lesson = await _lessonRepository.GetLessonById(lessonId);
            if (lesson == null)
            {
                throw new NotFoundException("Lesson not found");
            }

            var existingStudent = lesson.LessonStudents?.FirstOrDefault(ls => ls.StudentId == studentId);
            if (existingStudent != null)
            {
                throw new ConflictException("Student already exists in the lesson");
            }

            var student = await _studentRepository.GetStudentById(studentId);
            if (student == null)
            {
                throw new NotFoundException("Student not found");
            }

            var lessonStudent = new LessonStudent
            {
                LessonId = lessonId,
                StudentId = studentId
            };

            lesson.LessonStudents ??= new List<LessonStudent>();
            lesson.LessonStudents.Add(lessonStudent);

            await _lessonRepository.UpdateLesson(lesson);
            await _lessonRepository.SaveChangesAsync();
        }
    }
}
