using NewLearningCloud.Domain.Entities;

namespace NewLearningCloud.Application.Interfaces
{
    public interface IUsuarioAcessoAppService
    {
        UsuarioAcesso GetAcessoByUsuarioId(string id);
        string GetLoginByEmailOrUser(string login);
    }
}
