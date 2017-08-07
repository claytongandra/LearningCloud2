using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using CommonServiceLocator.SimpleInjectorAdapter;
using Microsoft.Practices.ServiceLocation;
using NewLearningCloud.Application.Services;
using NewLearningCloud.Application.Interfaces;
using NewLearningCloud.Domain.Services;
using NewLearningCloud.Domain.Interfaces.Services;
using NewLearningCloud.Domain.Interfaces.Repositories;
using NewLearningCloud.Infra.Data.EntityFramework;
using NewLearningCloud.Infra.Data.Repositories;
using NewLearningCloud.Infra.CrossCutting.Identity.ContextIdentity;
using NewLearningCloud.Infra.CrossCutting.Identity.ViewModels;
using NewLearningCloud.Infra.CrossCutting.Identity.Configuration;

namespace NewLearningCloud.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            
            container.Register<IUnitOfWorkRepository, UnitOfWorkRepository>(Lifestyle.Scoped);
            //container.Register<IUnitOfWorkRepository>(() => new UnitOfWorkRepository(),Lifestyle.Scoped);
            
            container.Register<IAulaAppService, AulaAppService>(Lifestyle.Scoped);
            container.Register<IAulaService, AulaService>(Lifestyle.Scoped);
            container.Register<IAulaRepository, AulaRepository>(Lifestyle.Scoped);

            container.Register<IAssinaturaNivelAppService, AssinaturaNivelAppService>(Lifestyle.Scoped);
            container.Register<IAssinaturaNivelService, AssinaturaNivelService>(Lifestyle.Scoped);
            container.Register<IAssinaturaNivelRepository, AssinaturaNivelRepository>(Lifestyle.Scoped);

            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()),Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);

            container.Register<IUsuarioAcessoRepository, UsuarioAcessoRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioAcessoAppService, UsuarioAcessoAppService>();
            container.Register<IUsuarioAcessoService, UsuarioAcessoService>();


            var adapter = new SimpleInjectorServiceLocatorAdapter(container);
            ServiceLocator.SetLocatorProvider(() => adapter);
        }
    }
}
