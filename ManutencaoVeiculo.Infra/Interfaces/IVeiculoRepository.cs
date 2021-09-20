using ManutencaoVeiculo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManutencaoVeiculo.Infra.Interfaces
{
    public interface IVeiculoRepository
    {
        IEnumerable<Veiculo> ObterTodosVeiculos();
        Veiculo ObterVeiculoPorId(int Id);
        Veiculo ObterVeiculoPorPlaca(string Placa);
        void AdicionarVeiculo(Veiculo veiculo);

        void AtualizarVeiculo(Veiculo veiculo);
        void RemoverVeiculo(Veiculo veiculo);

    }
}
