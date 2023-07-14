using System.Collections.Generic;
using System.Threading.Tasks;
using Student_Journal_Manager.Models;

namespace Student_Journal_Manager.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task AddStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(int id);
    }
}