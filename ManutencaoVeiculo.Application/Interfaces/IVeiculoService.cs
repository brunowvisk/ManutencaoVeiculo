using ManutencaoVeiculo.Domain.Entities;

namespace ManutencaoVeiculo.Application.Interfaces
{
    public interface IVeiculoService
    {
        ReturnDefault AdicionarVeiculo(Veiculo veiculo);
        ReturnDefault ListarVeiculos();
        ReturnDefault ObterVeiculoPorPlaca(string placa);
        ReturnDefault AtualizarVeiculo(string placa, Veiculo veiculoatualizado);
        ReturnDefault RemoverVeiculo(string placa);

    }
}
