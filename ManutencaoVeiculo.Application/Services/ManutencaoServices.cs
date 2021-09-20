using ManutencaoVeiculo.Application.Interfaces;
using ManutencaoVeiculo.Domain.Entities;
using ManutencaoVeiculo.Infra.Interfaces;
using System;
using System.Linq;

namespace ManutencaoVeiculo.Application.Services
{
    public class ManutencaoServices : IManutencaoService
    {
        private readonly IManutencaoRepository _manutencaoRepository;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IPessoaRepository _pessoaRepository;

        public ManutencaoServices(IManutencaoRepository manutencaoRepository, IVeiculoRepository veiculoRepository
            ,IPessoaRepository pessoaRepository)
        {
            _manutencaoRepository = manutencaoRepository;
            _veiculoRepository = veiculoRepository;
            _pessoaRepository = pessoaRepository;
        }

        public ReturnDefault AdicionarManutencaoService(Manutencao manutencao)
        {
            try
            {
                var cars = _veiculoRepository.ObterVeiculoPorId(manutencao.VeiculoId);
                var person = _pessoaRepository.ObterPessoaPorId(manutencao.PessoaId);
                manutencao.DataManutencao = DateTime.Now;
                manutencao.DataProximaManutencao = manutencao.DataManutencao.AddDays(180);

                if (cars == null)
                {
                    return new ReturnDefault()
                    {
                        Sucesso = false,
                        Msg = "Veículo não encontrado!",
                        Dado = cars
                    };
                }

                _manutencaoRepository.AdicionarManutencao(manutencao);


                return new ReturnDefault() { Sucesso = true, Msg = "Manutenção cadastrada com sucesso!", Dado = manutencao };
            }
            catch (Exception e)
            {

                return new ReturnDefault() { Sucesso = false, Msg = $"Erro ao criar manutenção!{e}", Dado = null };
            }
        }

        public ReturnDefault AtualizarManutencao(int id, Manutencao manutencaoAtualizado)
        {
            try
            {
                //var validaplaca = Veiculo.TratarPlaca(placa);
                //if (!validaplaca.Valido)
                //{
                //    return ObterReturnDefault(validaplaca.Valido, validaplaca.Message, null);
                //}

                Manutencao manutencao = _manutencaoRepository.ObterManutencoes().Where(x => x.Veiculo.Id == id).FirstOrDefault();

                manutencao.Descricao = manutencaoAtualizado.Descricao;
                manutencao.DataManutencao = manutencaoAtualizado.DataManutencao;
                manutencao.Quantidade = manutencaoAtualizado.Quantidade;
                manutencao.DataProximaManutencao = manutencaoAtualizado.DataProximaManutencao;
                manutencao.Oficina = manutencaoAtualizado.Oficina;
                manutencao.TipoServico = manutencaoAtualizado.TipoServico;

                _manutencaoRepository.AtualizarManutencao(manutencao);

                return new ReturnDefault() { Sucesso = true, Msg = "Serviço de manutenção atualizado com sucesso!", Dado = manutencao };
            }
            catch (Exception e)
            {

                return ObterReturnDefault(false, $"Erro ao atualizar serviço de manutenção!{e}", null);
            }
        }

        public ReturnDefault ListarManutencao()
        {
            var manutencao = _manutencaoRepository.ObterManutencoes();
            return ObterReturnDefault(true, "Serviços cadastrados", manutencao);
        }

        public ReturnDefault ObterManutencaoPorId(int Id)
        {
            var manutencao = _manutencaoRepository.ObterManutencoes().Where(x => x.Id == Id);
            return ObterReturnDefault(true, "Serviço de manutenção encontrado com sucesso!", manutencao);
        }

        public ReturnDefault ObterManutencaoPorPlaca(string placa)
        {
            var validaplaca = Manutencao.TratarPlaca(placa);
            if (!validaplaca.Valido)
            {
                return ObterReturnDefault(validaplaca.Valido, validaplaca.Message, null);
            }
            var manutencao = _manutencaoRepository.ObterManutencoes().Where(x => x.Veiculo.Placa == validaplaca.Dado.ToString());
            return ObterReturnDefault(true, "Serviço de manutenção encontrado com sucesso!", manutencao);
        }

        public ReturnDefault RemoverManutencao(int id)
        {
            //var validaplaca = Manutencao.TratarPlaca(placa);
            //if (!validaplaca.Valido)
            //{
            //    return ObterReturnDefault(validaplaca.Valido, validaplaca.Message, null);
            //}

            //Manutencao manutencao = _manutencaoRepository.ObterManutencaoPorPlaca(validaplaca.Dado.ToString());

            Manutencao manutencao = _manutencaoRepository.ObterManutencoes().Where(x => x.Id == id).FirstOrDefault();
            //Manutencao manutencao = _manutencaoRepository.ObterManutencaoPorId(id);

            _manutencaoRepository.RemoverManutencao(manutencao);

            return new ReturnDefault() { Sucesso = true, Msg = "Manutenção removida com sucesso!", Dado = manutencao };



            //Manutencao manutencao = _context.Pessoas.Where(x => x.Id == Id).FirstOrDefault();

            //_manutencaoRepository.RemoverManutencao(manutencao);

            //return new ReturnDefault() { Sucesso = true, Msg = "Veículo removido com sucesso!", Dado = manutencao };
        }

        private ReturnDefault ObterReturnDefault(bool Sucesso, string Msg, object Dado)
        {
            return new ReturnDefault() { Sucesso = Sucesso, Msg = Msg, Dado = Dado };
        }

    }

}
