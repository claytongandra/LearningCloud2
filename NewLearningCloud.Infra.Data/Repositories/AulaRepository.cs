using System.Linq;
using System.Collections.Generic;
using NewLearningCloud.Domain.Entities;
using NewLearningCloud.Domain.Interfaces.Repositories;


namespace NewLearningCloud.Infra.Data.Repositories
{
    public class AulaRepository : RepositoryBase<Aula>, IAulaRepository
    {
        public IEnumerable<Aula> GetByStatus(string status)
        {
            string[] arrayStatus = status.Split(',');

            return ContextDB.Set<Aula>().Where(a => arrayStatus.Contains(a.Aula_Status)).ToList();
        }
    }
}



