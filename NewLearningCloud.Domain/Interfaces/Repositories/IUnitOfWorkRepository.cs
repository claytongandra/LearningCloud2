
namespace NewLearningCloud.Domain.Interfaces.Repositories
{
    public interface IUnitOfWorkRepository
    {
        void BeginTransactionUoW();
        void CommitUoW();
    }
}
