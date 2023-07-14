using System.Collections.Generic;
using System.Threading.Tasks;
using Student_Journal_Manager.Models;

namespace Student_Journal_Manager.Repositories
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAllAttendances();
        Task<Attendance> GetAttendanceById(int id);
        Task AddAttendance(Attendance attendance);
        Task UpdateAttendance(Attendance attendance);
        Task DeleteAttendance(int id);
        Task SaveAttendance(Attendance attendance);

    }
}
