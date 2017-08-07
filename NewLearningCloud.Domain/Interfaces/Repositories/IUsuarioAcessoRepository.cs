using System;
using NewLearningCloud.Domain.Entities;

namespace NewLearningCloud.Domain.Interfaces.Repositories
{
    public interface IUsuarioAcessoRepository : IDisposable
    {
        UsuarioAcesso GetAcessoByUsuarioId(string id);
        string GetLoginByEmailOrUser(string login);
    }
}
