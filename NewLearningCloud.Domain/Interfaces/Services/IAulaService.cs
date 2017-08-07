using System.Collections.Generic;
using NewLearningCloud.Domain.Entities;

namespace NewLearningCloud.Domain.Interfaces.Services
{
    public interface IAulaService : IServiceBase<Aula>
    {
        IEnumerable<Aula> GetByStatus(string status);
    }
}
