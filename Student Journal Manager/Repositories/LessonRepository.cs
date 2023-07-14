using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student_Journal_Manager.Context;
using Student_Journal_Manager.Models;

namespace Student_Journal_Manager.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly MyDbContext _dbContext;

        public LessonRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Lesson>> GetAllLessons()
        {
            return await _dbContext.Lessons.ToListAsync();
        }

        public async Task<Lesson> GetLessonById(int id)
        {
            return await _dbContext.Lessons.FindAsync(id);
        }

        public async Task AddLesson(Lesson lesson)
        {
            _dbContext.Lessons.Add(lesson);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateLesson(Lesson lesson)
        {
            _dbContext.Entry(lesson).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteLesson(int id)
        {
            var lesson = await _dbContext.Lessons.FindAsync(id);
            if (lesson != null)
            {
                _dbContext.Lessons.Remove(lesson);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}