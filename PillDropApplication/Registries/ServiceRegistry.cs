using PillDrop.Domain.Contracts;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Implementation.Implementation.Helpers;
using PillDrop.Implementation.Implementation.Repository;
using PillDrop.Implementation.Implementation.Services;
using StructureMap.Configuration.DSL;

namespace PillDropApplication.Registries
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            For(typeof(IRepository<>)).Use(typeof(Repository<>));
            For<IApplicationConfiguration>().Singleton().Use<ApplicationConfiguration>();
            For<IAuthenticationService>().Use<AuthenticationService>();

            For<IUserRepository>().Use<UserRepository>();
            For<IUserService>().Use<UserService>();

            For<IEmailArchiveRepository>().Use<EmailArchiveRepository>();
            For<IEmailArchiveService>().Use<EmailArchiveService>();

            For<IRecoveryQuestionService>().Use<RecoveryQuestionService>();
            For<IRecoveryQuestionRepository>().Use<RecoveryQuestionRepository>();

            For<IPatientRepository>().Use<PatientRepository>();
            For<IPatientService>().Use<PatientService>();

            For<IPillDrooperRepository>().Use<PillDropperRepository>();
            For<IPillDropperService>().Use<PillDropperService>();

            For<IDemographicsRepository>().Use<DemographicsRepository>();
            For<IDemographicsService>().Use<DemographicsService>();
        }
    }
}