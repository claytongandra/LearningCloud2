using NewLearningCloud.Domain.Entities;

namespace NewLearningCloud.Domain.Interfaces.Services
{
    public interface IUsuarioAcessoService
    {
        UsuarioAcesso GetAcessoByUsuarioId(string id);
        string GetLoginByEmailOrUser(string login);
    }
}
