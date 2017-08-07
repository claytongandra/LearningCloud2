using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using NewLearningCloud.Domain.Entities;
using NewLearningCloud.Domain.Interfaces.Repositories;
using NewLearningCloud.Infra.Data.EntityFramework;
using NewLearningCloud.Infra.Data.Context;
using System.Threading.Tasks;

namespace NewLearningCloud.Infra.Data.Repositories
{
    public class UsuarioAcessoRepository : IUsuarioAcessoRepository
    {
        protected DbContext IdentityContextDB { get; private set; }

        public UsuarioAcessoRepository()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager<UsuarioNewLearningCloudContext>>();
            IdentityContextDB = contextManager.GetContext;
        }


        public UsuarioAcesso GetAcessoByUsuarioId(string id)
        {
            return IdentityContextDB.Set<UsuarioAcesso>().Find(id);
        }

        public string GetLoginByEmailOrUser(string login)
        {
            UsuarioAcesso retornoQueryUser = (from UserLogin in IdentityContextDB.Set<UsuarioAcesso>()
                                              where (UserLogin.UsuarioAcesso_Email == login || UserLogin.UsuarioAcesso_UserName == login)
                                              select UserLogin).SingleOrDefault();

            if (retornoQueryUser == null)
            {
                return null;
            }

            return retornoQueryUser.UsuarioAcesso_UserName;
        }
               
        public void Dispose()
        {
            IdentityContextDB.Dispose();
        }
    }
}
