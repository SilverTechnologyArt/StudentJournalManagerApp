using System.Collections.Generic;
using System.Threading.Tasks;
using Student_Journal_Manager.Models;
using Student_Journal_Manager.Repositories;

namespace Student_Journal_Manager.Services
{
    public class GuardianService : IGuardianService
    {
        private readonly IGuardianRepository _guardianRepository;

        public GuardianService(IGuardianRepository guardianRepository)
        {
            _guardianRepository = guardianRepository;
        }

        public async Task<List<Guardian>> GetAllGuardians()
        {
            return await _guardianRepository.GetAllGuardians();
        }

        public async Task<Guardian> GetGuardianById(int id)
        {
            return await _guardianRepository.GetGuardianById(id);
        }

        public async Task AddGuardian(Guardian guardian)
        {
            await _guardianRepository.AddGuardian(guardian);
        }

        public async Task UpdateGuardian(Guardian guardian)
        {
            await _guardianRepository.UpdateGuardian(guardian);
        }

        public async Task DeleteGuardian(int id)
        {
            await _guardianRepository.DeleteGuardian(id);
        }
    }
}
