using ManutencaoVeiculo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManutencaoVeiculo.Data
{
    public class ManutencaoContext : DbContext
    {
        public ManutencaoContext(DbContextOptions<ManutencaoContext> opt) : base(opt)
        {

        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Manutencao> Manutencoes { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<TipoVeiculo> TipoVeiculos { get; set; }

    }
}
