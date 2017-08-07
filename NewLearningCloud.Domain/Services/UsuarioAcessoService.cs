using System;
using NewLearningCloud.Domain.Entities;
using NewLearningCloud.Domain.Interfaces.Services;
using NewLearningCloud.Domain.Interfaces.Repositories;

namespace NewLearningCloud.Domain.Services
{
    public class UsuarioAcessoService : IUsuarioAcessoService
    {
        private readonly IUsuarioAcessoRepository _usuarioAcessoRepository;

        public UsuarioAcessoService(IUsuarioAcessoRepository usuarioAcessoRepository)
        {
            _usuarioAcessoRepository = usuarioAcessoRepository;
        }


        public UsuarioAcesso GetAcessoByUsuarioId(string id)
        {
            return _usuarioAcessoRepository.GetAcessoByUsuarioId(id);
        }

        public string GetLoginByEmailOrUser(string login)
        {
            return _usuarioAcessoRepository.GetLoginByEmailOrUser(login);
        }
    }
}
