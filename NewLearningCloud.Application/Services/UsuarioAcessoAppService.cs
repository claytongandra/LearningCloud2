using System;
using NewLearningCloud.Application.Interfaces;
using NewLearningCloud.Domain.Entities;
using NewLearningCloud.Domain.Interfaces.Services;

namespace NewLearningCloud.Application.Services
{
    public class UsuarioAcessoAppService : IUsuarioAcessoAppService
    {
        private readonly IUsuarioAcessoService _usuarioAcessoService;

        public UsuarioAcessoAppService(IUsuarioAcessoService usuarioAcessoService)
        {
            _usuarioAcessoService = usuarioAcessoService;
        }

        public UsuarioAcesso GetAcessoByUsuarioId(string id)
        {
            return _usuarioAcessoService.GetAcessoByUsuarioId(id);
        }

        public string GetLoginByEmailOrUser(string login)
        {
            return _usuarioAcessoService.GetLoginByEmailOrUser(login);
        }
    }
}
