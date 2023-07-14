using Student_Journal_Manager.Models;

namespace Student_Journal_Manager.Services
{
    public interface IAttendanceService
    {
        Task<List<Attendance>> GetAllAttendances();
        Task<Attendance> GetAttendanceById(int id);
        Task AddAttendance(Attendance attendance);
        Task UpdateAttendance(Attendance attendance);
        Task DeleteAttendance(int id);
        Task SaveAttendance(Attendance attendance);
        //Task<int[]> GetHoursForDate(int lessonId, DateTime date);
        //Task<Attendance> GetAttendance(int studentId, int lessonId, DateTime date);
    }
}
