using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using SAEC.Dominio.Entidades;

namespace SAEC.InfraEstrutura.Data.Contexto
{
    public class ContextoEF : DbContext
    {
        public ContextoEF() : base("SAECDBConnection")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Database.SetInitializer<ContextoEF>(null); //Desabilitar criação automatica 

            Configuration.LazyLoadingEnabled = true; // melhora performance no codigo;
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<ResponsavelAluno> ResponsavelAluno { get; set; }


        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataInclusao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataInclusao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataInclusao").IsModified = false;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
