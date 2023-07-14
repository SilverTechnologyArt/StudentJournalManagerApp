using System.Collections.Generic;
using System.Threading.Tasks;
using Student_Journal_Manager.Models;
using Student_Journal_Manager.Repositories;

namespace Student_Journal_Manager.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<List<Attendance>> GetAllAttendances()
        {
            return await _attendanceRepository.GetAllAttendances();
        }

        public async Task<Attendance> GetAttendanceById(int id)
        {
            return await _attendanceRepository.GetAttendanceById(id);
        }

        public async Task AddAttendance(Attendance attendance)
        {
            await _attendanceRepository.AddAttendance(attendance);
        }

        public async Task UpdateAttendance(Attendance attendance)
        {
            await _attendanceRepository.UpdateAttendance(attendance);
        }

        public async Task DeleteAttendance(int id)
        {
            await _attendanceRepository.DeleteAttendance(id);
        }

        public async Task SaveAttendance(Attendance attendance)
        {
            await _attendanceRepository.SaveAttendance(attendance);
        }
    }
}