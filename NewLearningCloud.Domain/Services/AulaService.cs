using System;
using System.Collections.Generic;
using NewLearningCloud.Domain.Entities;
using NewLearningCloud.Domain.Interfaces.Repositories;
using NewLearningCloud.Domain.Interfaces.Services;

namespace NewLearningCloud.Domain.Services
{
    public class AulaService : ServiceBase<Aula>, IAulaService
    {
        private readonly IAulaRepository _aulaRepository;

        public AulaService(IAulaRepository aulaRepository)
            : base(aulaRepository)
        {
            _aulaRepository = aulaRepository;
        }

        public IEnumerable<Aula> GetByStatus(string status)
        {
            return _aulaRepository.GetByStatus(status);
        }
    }
}
