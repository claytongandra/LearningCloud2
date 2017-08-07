using System.Collections.Generic;
using NewLearningCloud.Domain.Entities;

namespace NewLearningCloud.Domain.Interfaces.Repositories
{
    public interface IAulaRepository: IRepositoryBase<Aula>
    {
        IEnumerable<Aula> GetByStatus(string status);
    }
}
