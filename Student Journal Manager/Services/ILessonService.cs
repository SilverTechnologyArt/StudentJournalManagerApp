using System.Collections.Generic;
using System.Threading.Tasks;
using Student_Journal_Manager.Models;

namespace Student_Journal_Manager.Services
{
    public interface ILessonService
    {
        Task<List<Lesson>> GetAllLessons();
        Task<Lesson> GetLessonById(int id);
        Task AddLesson(Lesson lesson);
        Task UpdateLesson(Lesson lesson);
        Task DeleteLesson(int id);
        Task AddStudentToLesson(int lessonId, int studentId);
        Task RemoveStudentFromLesson(int lessonId, int studentId);
    }
}
