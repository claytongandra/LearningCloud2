namespace NewLearningCloud.Infra.Data.Migrations
{
    using Domain.Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.NewLearningCloudContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.NewLearningCloudContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.AssinaturaNivel.AddOrUpdate(
               asn => asn.AssinaturaNivel_Id,
               new AssinaturaNivel()
               {
                   AssinaturaNivel_Id = 1,
                   AssinaturaNivel_Titulo = "Assinatura Gratuita",
                   AssinaturaNivel_Descricao = "Assinatura Gratuita - Todos os usuário cadastrados através do site sem assinatura definida.",
                   AssinaturaNivel_Nivel = 10,
                   AssinaturaNivel_Status = "A"
               },
               new AssinaturaNivel()
               {
                   AssinaturaNivel_Id = 2,
                   AssinaturaNivel_Titulo = "Assinatura Premium",
                   AssinaturaNivel_Descricao = "Assinatura Premium - Usuários com acessos a todos os conteúdos",
                   AssinaturaNivel_Nivel = 20,
                   AssinaturaNivel_Status = "A"

               });
        }
    }
}
