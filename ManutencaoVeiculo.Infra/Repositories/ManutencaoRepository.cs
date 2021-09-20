using ManutencaoVeiculo.Data;
using ManutencaoVeiculo.Domain.Entities;
using ManutencaoVeiculo.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManutencaoVeiculo.Infra.Repositories
{
    public class ManutencaoRepository : IManutencaoRepository
    {
        private readonly ManutencaoContext _context;

        public ManutencaoRepository(ManutencaoContext context)
        {
            _context = context;
        }
        public void AdicionarManutencao(Manutencao manutencao)
        {
            _context.Add(manutencao);
            _context.SaveChanges(); ;
        }

        public IEnumerable<Manutencao> ObterManutencoes()
        {
            return _context.Manutencoes.Include(x => x.Veiculo).Include(x => x.Pessoa);
        }

        public void AtualizarManutencao(Manutencao manutencao)
        {
            _context.Update(manutencao);
            _context.SaveChanges();
        }

        public void RemoverManutencao(Manutencao manutencao)
        {
            _context.Remove(manutencao);
            _context.SaveChanges();
        }

        public Manutencao ObterManutencaoPorId(int Id)
        {
            return _context.Manutencoes.Where(x => x.Veiculo.Id == Id).FirstOrDefault();
        }

        public Manutencao ObterManutencaoPorPlaca(string Placa)
        {
            return _context.Manutencoes.Where(x => x.Veiculo.Placa == Placa).FirstOrDefault();
        }

    }
}
