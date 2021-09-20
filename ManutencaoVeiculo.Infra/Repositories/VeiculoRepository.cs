using ManutencaoVeiculo.Data;
using ManutencaoVeiculo.Domain.Entities;
using ManutencaoVeiculo.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManutencaoVeiculo.Infra.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly ManutencaoContext _context;

        public VeiculoRepository(ManutencaoContext context)
        {
            _context = context;
        }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            _context.Add(veiculo);
            _context.SaveChanges();
        }

        public void AtualizarVeiculo(Veiculo veiculo)
        {
            _context.Update(veiculo);
            _context.SaveChanges();
        }

        public void RemoverVeiculo(Veiculo veiculo)
        {
            _context.Remove(veiculo);
            _context.SaveChanges();
        }

        public IEnumerable<Veiculo> ObterTodosVeiculos()
        {
            return _context.Veiculos;
        }

        public Veiculo ObterVeiculoPorId(int Id)
        {
            return _context.Veiculos.Where(x => x.Id == Id).FirstOrDefault();
        }

        public Veiculo ObterVeiculoPorPlaca(string Placa)
        {
            return _context.Veiculos.Where(x => x.Placa == Placa).FirstOrDefault();
        }

    }
}
