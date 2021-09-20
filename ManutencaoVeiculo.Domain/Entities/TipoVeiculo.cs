using ManutencaoVeiculo.Shared;
using System.ComponentModel.DataAnnotations;

namespace ManutencaoVeiculo.Domain.Entities
{
    public class TipoVeiculo
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string DescricaoVeiculo { get; set; }

        public TipoVeiculo(string descricaoVeiculo)
        {
            DescricaoVeiculo = descricaoVeiculo;
        }

        public TipoVeiculo()
        {

        }
    }
}
