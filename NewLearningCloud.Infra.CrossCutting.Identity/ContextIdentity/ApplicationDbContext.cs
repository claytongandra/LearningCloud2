using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using NewLearningCloud.Domain.Entities;
using NewLearningCloud.Infra.CrossCutting.Identity.ViewModels;
using NewLearningCloud.Infra.Data.EntitiesConfig;

namespace NewLearningCloud.Infra.CrossCutting.Identity.ContextIdentity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("NewLearningCloud", throwIfV1Schema: false)
        {
        }

        public DbSet<Usuario> NewLearningCloud_Usuario { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
              .Where(p => p.Name.Contains("_Id"))
              .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
              .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
              .Configure(p => p.HasMaxLength(100));

            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UsuarioConfiguration());

            //  modelBuilder.HasDefaultSchema("");

            modelBuilder.Entity<ApplicationUser>().ToTable("NewLearningCloud_UsuarioAcesso").Property(p => p.Id).HasColumnName("uac_id");
            modelBuilder.Entity<ApplicationUser>().ToTable("NewLearningCloud_UsuarioAcesso").Property(p => p.UserName).HasColumnName("uac_userName");
            modelBuilder.Entity<ApplicationUser>().ToTable("NewLearningCloud_UsuarioAcesso").Property(p => p.Email).HasColumnName("uac_email").IsRequired();
            modelBuilder.Entity<ApplicationUser>().ToTable("NewLearningCloud_UsuarioAcesso").Property(p => p.EmailConfirmed).HasColumnName("uac_emailConfirmed");
            modelBuilder.Entity<ApplicationUser>().ToTable("NewLearningCloud_UsuarioAcesso").Property(p => p.PasswordHash).HasColumnName("uac_passwordHash");
            modelBuilder.Entity<ApplicationUser>().ToTable("NewLearningCloud_UsuarioAcesso").Property(p => p.SecurityStamp).HasColumnName("uac_securityStamp");
            modelBuilder.Entity<ApplicationUser>().ToTable("NewLearningCloud_UsuarioAcesso").Property(p => p.PhoneNumber).HasColumnName("uac_phoneNumber");
            modelBuilder.Entity<ApplicationUser>().ToTable("NewLearningCloud_UsuarioAcesso").Property(p => p.PhoneNumberConfirmed).HasColumnName("uac_phoneNumberConfirmed");
            modelBuilder.Entity<ApplicationUser>().ToTable("NewLearningCloud_UsuarioAcesso").Property(p => p.TwoFactorEnabled).HasColumnName("uac_twoFactorEnabled");
            modelBuilder.Entity<ApplicationUser>().ToTable("NewLearningCloud_UsuarioAcesso").Property(p => p.LockoutEndDateUtc).HasColumnName("uac_lockoutEndDateUtc");
            modelBuilder.Entity<ApplicationUser>().ToTable("NewLearningCloud_UsuarioAcesso").Property(p => p.LockoutEnabled).HasColumnName("uac_lockoutEnabled");
            modelBuilder.Entity<ApplicationUser>().ToTable("NewLearningCloud_UsuarioAcesso").Property(p => p.AccessFailedCount).HasColumnName("uac_accessFailedCount");
            modelBuilder.Entity<ApplicationUser>().ToTable("NewLearningCloud_UsuarioAcesso").Property(p => p.UsuarioAcesso_Nivel).HasColumnName("uac_nivelAcesso"); //.IsOptional();
            modelBuilder.Entity<ApplicationUser>().ToTable("NewLearningCloud_UsuarioAcesso").HasRequired(x => x.UsuarioAcesso_Usuario).WithRequiredDependent().Map(p => p.MapKey("uac_fk_usuario"));
            

            modelBuilder.Entity<IdentityUserRole>().ToTable("NewLearningCloud_UsuariosRoles").Property(p => p.UserId).HasColumnName("uro_usuarioId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("NewLearningCloud_UsuariosRoles").Property(p => p.RoleId).HasColumnName("uro_roleId");

            modelBuilder.Entity<IdentityUserLogin>().ToTable("NewLearningCloud_UsuariosLogins").Property(p => p.UserId).HasColumnName("ulo_usuarioId");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("NewLearningCloud_UsuariosLogins").Property(p => p.LoginProvider).HasColumnName("ulo_loginProvider");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("NewLearningCloud_UsuariosLogins").Property(p => p.ProviderKey).HasColumnName("ulo_providerKey");

            modelBuilder.Entity<IdentityUserClaim>().ToTable("NewLearningCloud_UsuariosClaims").Property(p => p.Id).HasColumnName("ucl_id");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("NewLearningCloud_UsuariosClaims").Property(p => p.UserId).HasColumnName("ucl_usuarioId");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("NewLearningCloud_UsuariosClaims").Property(p => p.ClaimType).HasColumnName("ucl_claimType");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("NewLearningCloud_UsuariosClaims").Property(p => p.ClaimValue).HasColumnName("ucl_claimValue");

            modelBuilder.Entity<IdentityRole>().ToTable("NewLearningCloud_Roles").Property(p => p.Id).HasColumnName("rol_id");
            modelBuilder.Entity<IdentityRole>().ToTable("NewLearningCloud_Roles").Property(p => p.Name).HasColumnName("rol_name");
                
        }


        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.State != EntityState.Deleted)
                {
                    string dataCadastro = null;
                    string dataAlteracao = null;

                    foreach (string o in entry.CurrentValues.PropertyNames)
                    {
                        var property = entry.Property(o);

                        if (property.Name.Contains("_DataCadastro"))
                        {
                            dataCadastro = property.Name;
                        }
                        if (property.Name.Contains("_DataAlteracao"))
                        {
                            dataAlteracao = property.Name.ToString();
                        }
                    }

                    if (entry.State == EntityState.Added)
                    {
                        if (dataCadastro != null)
                        {
                            entry.Property(dataCadastro).CurrentValue = DateTime.Now;
                        }
                        if (dataAlteracao != null)
                        {
                            entry.Property(dataAlteracao).CurrentValue = null;
                        }
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        if (dataCadastro != null)
                        {
                            entry.Property(dataCadastro).IsModified = false;
                        }
                        if (dataAlteracao != null)
                        {
                            entry.Property(dataAlteracao).CurrentValue = DateTime.Now;
                        }
                    }
                }
            }

            try
            {
                return base.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            //return base.SaveChanges();
        }


    }
}
