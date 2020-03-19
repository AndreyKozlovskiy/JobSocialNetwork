using BusinessLogic.Models;
using BusinessLogic.Repositories;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ResumeService : IResumeService
    {
        private readonly IResumeRepository resumeRepository;
        public ResumeService(IResumeRepository resumeRepository)
        {
            this.resumeRepository = resumeRepository;
        }

        public async Task AddAsync(Resume resume)
        {
            await resumeRepository.AddAsync(resume);
        }

        public async Task RemoveAsync(int resumeId)
        {
            await resumeRepository.RemoveAsync(resumeId);
        }

        public async Task UpdateAsync(int resumeId, Resume newResume)
        {
            await resumeRepository.UpdateAsync(resumeId, newResume);
        }
    }
}
