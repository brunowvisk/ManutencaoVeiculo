using ManutencaoVeiculo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManutencaoVeiculo.Infra.Interfaces
{
    public interface IManutencaoRepository
    {
        void AdicionarManutencao(Manutencao manutencao);
        IEnumerable<Manutencao> ObterManutencoes();
        void AtualizarManutencao(Manutencao manutencao);
        void RemoverManutencao(Manutencao manutencao);
        Manutencao ObterManutencaoPorPlaca(string Placa);
        Manutencao ObterManutencaoPorId(int Id);
    }

}
