using ManutencaoVeiculo.Data;
using ManutencaoVeiculo.Domain.Entities;
using ManutencaoVeiculo.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManutencaoVeiculo.Infra.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {

        private readonly ManutencaoContext _context;

        public PessoaRepository(ManutencaoContext context)
        {
            _context = context;
        }

        public void AdicionarPessoa(Pessoa pessoa)
        {
            _context.Add(pessoa);
            _context.SaveChanges();
        }

        public void AtualizarPessoa(Pessoa pessoa)
        {
            _context.Update(pessoa);
            _context.SaveChanges();
        }

        public void RemoverPessoa(Pessoa pessoa)
        {
            _context.Remove(pessoa);
            _context.SaveChanges();
        }

        public Pessoa ObterPessoaPorId(int Id)
        {
            return _context.Pessoas.Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Pessoa> ListarPessoas()
        {
            return _context.Pessoas;
        }

        public Pessoa ObterPessoaPorCpf(string Cpf)
        {
            return _context.Pessoas.Where(x => x.Cpf == Cpf).FirstOrDefault();
        }



    }
}
