using BusinessLogic.Models;
using BusinessLogic.Repositories;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository skillRepository;
        public SkillService(ISkillRepository skillRepository)
        {
            this.skillRepository = skillRepository;
        }

        public async Task AddAsync(Skill Skill)
        {
            await skillRepository.AddAsync(Skill);
        }

        public async Task RemoveAsync(int SkillId)
        {
            await skillRepository.RemoveAsync(SkillId);
        }

        public async Task UpdateAsync(int SkillId, Skill newSkill)
        {
            await skillRepository.UpdateAsync(SkillId, newSkill);
        }
    }
}
