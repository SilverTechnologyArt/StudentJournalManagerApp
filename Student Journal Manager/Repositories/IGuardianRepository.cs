using System.Collections.Generic;
using System.Threading.Tasks;
using Student_Journal_Manager.Models;

namespace Student_Journal_Manager.Repositories
{
    public interface IGuardianRepository
    {
        Task<List<Guardian>> GetAllGuardians();
        Task<Guardian> GetGuardianById(int id);
        Task AddGuardian(Guardian guardian);
        Task UpdateGuardian(Guardian guardian);
        Task DeleteGuardian(int id);
    }
}
