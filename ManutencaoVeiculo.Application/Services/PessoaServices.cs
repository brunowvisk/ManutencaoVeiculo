using ManutencaoVeiculo.Application.Interfaces;
using ManutencaoVeiculo.Data;
using ManutencaoVeiculo.Domain.Entities;
using ManutencaoVeiculo.Infra.Interfaces;
using System;
using System.Linq;

namespace ManutencaoVeiculo.Application.Services
{
    public class PessoaServices : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaServices(IPessoaRepository pessoaRepository)
        {

            _pessoaRepository = pessoaRepository;

        }

        public ReturnDefault AdicionarPessoa(Pessoa pessoa)
        {
            try
            {
                var pessoas = _pessoaRepository.ObterPessoaPorCpf(pessoa.Cpf);

                //var pessoaExistente = pessoas.Where(x => x.Cpf == pessoa.Cpf).FirstOrDefault();

                if (pessoas != null)
                {
                    return new ReturnDefault()
                    {
                        Sucesso = false,
                        Msg = "CPF já cadastrado!",
                        Dado = pessoas
                    };
                }
                _pessoaRepository.AdicionarPessoa(pessoa);
                return new ReturnDefault() { Sucesso = true, Msg = "Usuário cadastrado com sucesso!", Dado = pessoa };



            }
            catch (Exception e)
            {
                return new ReturnDefault() { Sucesso = false, Msg = $"Erro ao cadastrar CPF!{e}", Dado = null };
            }
        }

        public ReturnDefault ListarPessoas()
        {
            var pessoas = _pessoaRepository.ListarPessoas();
            return ObterReturnDefault(true, "Usuários cadastrados", pessoas);
        }

        public ReturnDefault ObterPessoaPorCpf(string cpf)
        {
            var validacpf = Pessoa.TratarCpf(cpf);
            if (!validacpf.Valido)
            {
                return ObterReturnDefault(validacpf.Valido, validacpf.Message, null);
            }
            var pessoa = _pessoaRepository.ListarPessoas().Where(x => x.Cpf == validacpf.Dado.ToString());
            return ObterReturnDefault(true, "Usuário encontrado com sucesso!", pessoa);
        }

        public ReturnDefault AtualizarPessoa(string Cpf, Pessoa pessoaAtualizado)
        {
            try
            {
                var validaCpf = Pessoa.TratarCpf(Cpf);
                if (!validaCpf.Valido)
                {
                    return ObterReturnDefault(validaCpf.Valido, validaCpf.Message, null);
                }

                var pessoa = _pessoaRepository.ListarPessoas().Where(x => x.Cpf == validaCpf.Dado.ToString()).FirstOrDefault();

                pessoa.Nome = pessoaAtualizado.Nome;
                pessoa.Cpf = pessoaAtualizado.Cpf;
                pessoa.Habilitacao = pessoaAtualizado.Habilitacao;
                pessoa.Funcao = pessoaAtualizado.Funcao;

                _pessoaRepository.AtualizarPessoa(pessoa);
                
                return new ReturnDefault() { Sucesso = true, Msg = "Usuário atualizado com sucesso!", Dado = pessoa };
            }
            catch (Exception e)
            {

                return ObterReturnDefault(false, $"Erro ao atualizar cadastro!{e}", null);
            }
        }


        public ReturnDefault RemoverPessoa(string cpf)
        {
            //var validaCpf = Pessoa.TratarCpf(Cpf);
            //if (!validaCpf.Valido)
            //{
            //    return ObterReturnDefault(validaCpf.Valido, validaCpf.Message, null);
            //}

            Pessoa pessoa = _pessoaRepository.ListarPessoas().Where(x => x.Cpf == cpf).FirstOrDefault();

            _pessoaRepository.RemoverPessoa(pessoa);
            return new ReturnDefault() { Sucesso = true, Msg = "Usuário removido com sucesso!", Dado = pessoa };
        }

        private ReturnDefault ObterReturnDefault(bool Sucesso, string Msg, object Dado)
        {
            return new ReturnDefault() { Sucesso = Sucesso, Msg = Msg, Dado = Dado };
        }

    }
}
