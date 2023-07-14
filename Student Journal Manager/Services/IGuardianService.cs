using Student_Journal_Manager.Models;

namespace Student_Journal_Manager.Services
{
    public interface IGuardianService
    {
        Task<List<Guardian>> GetAllGuardians();
        Task<Guardian> GetGuardianById(int id);
        Task AddGuardian(Guardian guardian);
        Task UpdateGuardian(Guardian guardian);
        Task DeleteGuardian(int id);
    }
}
