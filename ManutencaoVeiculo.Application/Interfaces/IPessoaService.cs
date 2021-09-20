using ManutencaoVeiculo.Domain.Entities;

namespace ManutencaoVeiculo.Application.Interfaces
{
    public interface IPessoaService
    {
        ReturnDefault AdicionarPessoa(Pessoa pessoa);
        ReturnDefault ListarPessoas();
        ReturnDefault ObterPessoaPorCpf(string Cpf);
        ReturnDefault AtualizarPessoa(string Cpf, Pessoa pessoaAtualizado);
        ReturnDefault RemoverPessoa(string Cpf);
    }
}
