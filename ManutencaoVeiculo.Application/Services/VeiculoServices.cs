using ManutencaoVeiculo.Application.Interfaces;
using ManutencaoVeiculo.Domain.Entities;
using ManutencaoVeiculo.Infra.Interfaces;
using System;
using System.Linq;

namespace ManutencaoVeiculo.Application.Services
{
    public class VeiculoServices : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoServices(IVeiculoRepository veiculoRepository)
        {

            _veiculoRepository = veiculoRepository;

        }

        public ReturnDefault AdicionarVeiculo(Veiculo veiculo)
        {
            try
            {
                var cars = _veiculoRepository.ObterVeiculoPorPlaca(veiculo.Placa);

                if(cars != null)
                {
                    return new ReturnDefault()
                    {
                        Sucesso = false, Msg = "Veículo já existente!", Dado = cars
                    };
                }

                _veiculoRepository.AdicionarVeiculo(veiculo);

                return new ReturnDefault() { Sucesso = true, Msg="Veículo cadastrado com sucesso!",Dado=veiculo };
            }
            catch (Exception e)
            {

                return new ReturnDefault() { Sucesso = false, Msg = $"Erro ao criar veículo!{e}", Dado = null };
            }

        }

        public ReturnDefault ListarVeiculos()
        {
            var cars = _veiculoRepository.ObterTodosVeiculos();
            return ObterReturnDefault(true, "Veículo cadastrados", cars);
        }

        public ReturnDefault ObterVeiculoPorPlaca(string placa)
        {
            var validaplaca = Veiculo.TratarPlaca(placa);
            if (!validaplaca.Valido)
            {
                return ObterReturnDefault(validaplaca.Valido, validaplaca.Message, null);
            }
            var car = _veiculoRepository.ObterTodosVeiculos().Where(x => x.Placa == validaplaca.Dado.ToString());
            return ObterReturnDefault(true, "Veículo encontrado com sucesso!", car);
        }

        public ReturnDefault AtualizarVeiculo(string placa, Veiculo veiculoAtualizado)
        {
            try
            {
                var validaplaca = Veiculo.TratarPlaca(placa);
                if (!validaplaca.Valido)
                {
                    return ObterReturnDefault(validaplaca.Valido, validaplaca.Message, null);
                }

                Veiculo car = _veiculoRepository.ObterTodosVeiculos().Where(x => x.Placa == validaplaca.Dado.ToString()).FirstOrDefault();

                car.Marca = veiculoAtualizado.Marca;
                car.Modelo = veiculoAtualizado.Modelo;
                car.Cor = veiculoAtualizado.Cor;
                car.Chassi = veiculoAtualizado.Chassi;
                car.Quilometragem = veiculoAtualizado.Quilometragem;
                car.AnoFabricacao = veiculoAtualizado.AnoFabricacao;
                car.Status = veiculoAtualizado.Status;

                _veiculoRepository.AtualizarVeiculo(car);

                return new ReturnDefault() { Sucesso = true, Msg = "Veículo atualizado com sucesso!", Dado = car };
            }
            catch (Exception e)
            {

                return ObterReturnDefault(false, $"Erro ao atualizar cadastro de veículo!{e}", null);
            }

        }

        public ReturnDefault RemoverVeiculo(string placa)
        {
            var validaplaca = Veiculo.TratarPlaca(placa);
            if (!validaplaca.Valido)
            {
                return ObterReturnDefault(validaplaca.Valido, validaplaca.Message, null);
            }

            Veiculo car = _veiculoRepository.ObterVeiculoPorPlaca(validaplaca.Dado.ToString());

            _veiculoRepository.RemoverVeiculo(car);

            return new ReturnDefault() { Sucesso = true, Msg = "Veículo removido com sucesso!", Dado = car };
        }


        private ReturnDefault ObterReturnDefault(bool Sucesso, string Msg, object Dado)
        {
            return new ReturnDefault() { Sucesso = Sucesso, Msg = Msg, Dado = Dado };
        }

    }
}
