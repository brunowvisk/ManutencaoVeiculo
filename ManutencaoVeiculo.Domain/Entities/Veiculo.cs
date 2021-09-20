using ManutencaoVeiculo.Domain.Validations;
using ManutencaoVeiculo.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ManutencaoVeiculo.Domain.Entities
{
    public class Veiculo
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string Chassi { get; set; }
        public int Quilometragem  { get; set; }
        public int AnoFabricacao { get; set; }
        public string Status { get; set; }

        public string CriarPlaca(string placa)
        {
            Placa = placa;
            return Placa;
        }


        public Veiculo(int id, string marca, string modelo, string placa, string cor, string chassi, int quilometragem, int anoFabricacao, string status)
        {

            Id = id;
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
            Cor = cor;
            Chassi = chassi;
            Quilometragem = quilometragem;
            AnoFabricacao = anoFabricacao;
            Status = status;
        }

        public Veiculo()
        {

        }

        public static Validation TratarPlaca(string placa)
        {
            if(placa.Length < 7 || placa.Length > 8)
            {
                return new Validation() { Valido = false, Message = "A Placa deve estar no padrão XXX-XXXX !" };
            }
            placa = placa.Trim();
            return new Validation() { Valido = true, Message = placa, Dado = placa };
            
        }

    }
}
