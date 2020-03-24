using BusinessLogic.Contexts;
using BusinessLogic.Models;
using BusinessLogic.Repositories.Contracts;
using BusinessLogic.Services.Contracts;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ApplicationService
    {
        public readonly IUserService userService;
        public readonly IVacancyService vacancyService;
        public readonly IResumeService resumeService;
        public readonly ISkillService skillService;
        public readonly IDataContext dataContext;
        public readonly IResumeRepository resumeRepository;
        public readonly IVacancyRepository vacancyRepository;
        public readonly IUserRepository userRepository;
        public readonly ISkillRepository skillRepository;

        public ApplicationService(
            IDataContext dataContext,
            IUserService userService,
            IVacancyService vacancyService,
            IResumeService resumeService,
            ISkillService skillService,
            IUserRepository userRepository,
            ISkillRepository skillRepository,
            IVacancyRepository vacancyRepository,
            IResumeRepository resumeRepository)
        {
            this.dataContext = dataContext;
            this.userService = userService;
            this.vacancyService = vacancyService;
            this.resumeService = resumeService;
            this.skillService = skillService;
            this.resumeRepository = resumeRepository;
            this.skillRepository = skillRepository;
            this.userRepository = userRepository;
            this.vacancyRepository= vacancyRepository;
        }

        public async Task AddUserAsync(User user)
        {
            await userRepository.AddAsync(user);
            await dataContext.SaveChangesAsync();
        }

        public async Task AddVacancyAsync(Vacancy vacancy)
        {
            await vacancyService.AddAsync(vacancy);
        }
    }
}
