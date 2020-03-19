using BusinessLogic.Models;
using BusinessLogic.Repositories;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly IVacancyRepository VacancyRepository;
        public VacancyService(IVacancyRepository VacancyRepository)
        {
            this.VacancyRepository = VacancyRepository;
        }

        public async Task AddAsync(Vacancy Vacancy)
        {
            await VacancyRepository.AddAsync(Vacancy);
        }

        public async Task RemoveAsync(int VacancyId)
        {
            await VacancyRepository.RemoveAsync(VacancyId);
        }

        public async Task UpdateAsync(int VacancyId, Vacancy newVacancy)
        {
            await VacancyRepository.UpdateAsync(VacancyId, newVacancy);
        }
    }
}
