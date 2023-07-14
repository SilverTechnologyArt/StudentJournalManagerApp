using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student_Journal_Manager.Context;
using Student_Journal_Manager.Models;

namespace Student_Journal_Manager.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyDbContext _dbContext;

        public StudentRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _dbContext.Students.FindAsync(id);
        }

        public async Task AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            _dbContext.Entry(student).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteStudent(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
