using System.Data.Entity;
using NewLearningCloud.Domain.Entities;
using NewLearningCloud.Infra.Data.EntitiesConfig;

namespace NewLearningCloud.Infra.Data.Context
{
    class UsuarioNewLearningCloudContext : DbContext

    {
        public UsuarioNewLearningCloudContext()
            : base("NewLearningCloud")
        {

        }

        public DbSet<Usuario> NewLearningCloud_Usuario { get; set; }
        public DbSet<UsuarioAcesso> NewLearningCloud_UsuarioAcesso { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new UsuarioAcessoConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
