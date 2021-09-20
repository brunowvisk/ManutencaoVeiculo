using ManutencaoVeiculo.Domain.Enums;
using ManutencaoVeiculo.Domain.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManutencaoVeiculo.Domain.Entities
{
    public class Manutencao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [ForeignKey("Veiculo")]
        public int VeiculoId { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        [ForeignKey("Pessoa")]
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public string Descricao { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataManutencao { get; set; }
        public string Quantidade { get; set; }
        public DateTime DataProximaManutencao { get; set; }
        public string Oficina { get; set; }
        public EServiceType TipoServico { get; set; }


        public Manutencao(string descricao, DateTime dataManutencao, 
            string quantidade, DateTime dataProximaManutencao, string oficina, EServiceType tipoServico)
        {
            Descricao = descricao;
            DataManutencao = dataManutencao;
            Quantidade = quantidade;
            DataProximaManutencao = dataProximaManutencao;
            Oficina = oficina;
            TipoServico = tipoServico;
        }

        public Manutencao()
        {

        }

        public static Validation TratarPlaca(string placa)
        {
            if (placa.Length < 7 || placa.Length > 8)
            {
                return new Validation() { Valido = false, Message = "A Placa deve estar no padrão XXX-XXXX !" };
            }
            placa = placa.Trim();
            return new Validation() { Valido = true, Message = placa, Dado = placa };

        }

    }
}
