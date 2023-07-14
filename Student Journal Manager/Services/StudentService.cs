using Student_Journal_Manager.Context;
using Student_Journal_Manager.Models;
using Student_Journal_Manager.Repositories;

namespace Student_Journal_Manager.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _studentRepository.GetAllStudents();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _studentRepository.GetStudentById(id);
        }

        public async Task AddStudent(Student student)
        {
            await _studentRepository.AddStudent(student);
        }

        public async Task UpdateStudent(Student student)
        {
            await _studentRepository.UpdateStudent(student);
        }

        public async Task DeleteStudent(int id)
        {
            await _studentRepository.DeleteStudent(id);
        }
    }
}
