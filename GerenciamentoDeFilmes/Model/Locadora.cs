namespace GerenciamentoDeFilmes.Model
{
    using System.Data.Entity;

    public partial class Locadora : DbContext
    {
        public Locadora()
            : base("name=Locadora")
        {
        }

        public virtual DbSet<Filmes> Filmes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
