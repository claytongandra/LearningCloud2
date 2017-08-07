using NewLearningCloud.Domain.Entities;
using System.Collections.Generic;

namespace NewLearningCloud.Application.Interfaces
{
    public interface IAulaAppService : IAppServiceBase<Aula>
    {
        IEnumerable<Aula> GetByStatusAula(string status);
        void CreateAula(Aula aula);
        void UpdateAula(Aula aula);
        void ChangeStatusAula(Aula aula, string status);
    }
}
