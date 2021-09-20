using ManutencaoVeiculo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManutencaoVeiculo.Application.Interfaces
{
    public interface IManutencaoService
    {
        ReturnDefault AdicionarManutencaoService(Manutencao manutencao);
        ReturnDefault ListarManutencao();
        ReturnDefault ObterManutencaoPorId(int Id);
        ReturnDefault AtualizarManutencao(int Id, Manutencao manutencaoAtualizado);
        ReturnDefault RemoverManutencao(int Id);
    }
}
