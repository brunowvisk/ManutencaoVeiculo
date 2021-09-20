using ManutencaoVeiculo.Application.Interfaces;
using ManutencaoVeiculo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ManutencaoVeiculo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpPost]
        public IActionResult AdicionarPessoa([FromBody] Pessoa pessoa)
        {
            var cpf = _pessoaService.AdicionarPessoa(pessoa);
            return Ok(cpf);
        }

        [HttpGet]
        public IActionResult EncontrarPessoa()
        {
            return Ok(_pessoaService.ListarPessoas());
        }

        [HttpGet("{cpf}")]
        public IActionResult ObterPessoaPorCpf(string cpf)
        {
            var pessoa = _pessoaService.ObterPessoaPorCpf(cpf);
            if (pessoa.Sucesso)
            {
                return Ok(pessoa);
            }
            return NotFound();
        }

        [HttpPut("{cpf}")]
        public IActionResult AtualizarPessoa(string cpf, Pessoa pessoaatualizado)
        {
            var pessoa = _pessoaService.AtualizarPessoa(cpf, pessoaatualizado);
            if (pessoa.Sucesso)
            {
                return Ok(pessoa);
            }
            return NotFound();
        }

        [HttpDelete("{cpf}")]
        public IActionResult RemoverPessoa(string cpf)
        {

            var pessoa = _pessoaService.RemoverPessoa(cpf);
                if (pessoa.Sucesso)
                {
                    return Ok(pessoa);
                }
                return NoContent();
        }

    }

}
