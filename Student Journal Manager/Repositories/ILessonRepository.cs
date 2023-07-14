using System.Collections.Generic;
using System.Threading.Tasks;
using Student_Journal_Manager.Models;

namespace Student_Journal_Manager.Repositories
{
    public interface ILessonRepository
    {
        Task<List<Lesson>> GetAllLessons();
        Task<Lesson> GetLessonById(int id);
        Task AddLesson(Lesson lesson);
        Task UpdateLesson(Lesson lesson);
        Task DeleteLesson(int id);
        Task SaveChangesAsync();
    }
}
