using ManutencaoVeiculo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManutencaoVeiculo.Infra.Interfaces
{
    public interface IPessoaRepository
    {
        IEnumerable<Pessoa> ListarPessoas();
        Pessoa ObterPessoaPorId(int Id);
        Pessoa ObterPessoaPorCpf(string Cpf);
        void AdicionarPessoa(Pessoa pessoa);
        void AtualizarPessoa(Pessoa pessoa);
        void RemoverPessoa(Pessoa pessoa);
    }
}
