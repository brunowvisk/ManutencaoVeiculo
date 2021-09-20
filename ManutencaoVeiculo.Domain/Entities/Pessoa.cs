using ManutencaoVeiculo.Domain.Validations;
using ManutencaoVeiculo.Shared;
using System.ComponentModel.DataAnnotations;

namespace ManutencaoVeiculo.Domain.Entities
{
    public class Pessoa
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        //[StringLength(11, MinimumLength = 11, ErrorMessage ="O CPF deve conter 11 dígitos, sem pontos e/ou traços!")]
        public string Cpf { get; set; }
        public string Habilitacao { get; set; }
        public string Funcao { get; set; }

        public Pessoa(string nome, string cpf, string habilitacao, string funcao)
        {
            Nome = nome;
            Cpf = cpf;
            Habilitacao = habilitacao;
            Funcao = funcao;
        }

        public Pessoa()
        {

        }

        public static Validation TratarCpf(string cpf)
        {
            if (cpf.Length != 11)
            {
                return new Validation() { Valido = false, Message = "O CPF deve conter 11 dígitos, sem pontos ou traços!" };
            }
            cpf = cpf.Trim();
            return new Validation() { Valido = true, Message = cpf, Dado = cpf };

        }


    }
}
