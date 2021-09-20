using ManutencaoVeiculo.Application.Interfaces;
using ManutencaoVeiculo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ManutencaoVeiculo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManutencaoController : ControllerBase
    {

        private readonly IManutencaoService _manutencaoService;
        public ManutencaoController(IManutencaoService manutencaoService)
        {
            _manutencaoService = manutencaoService;
        }

        [HttpPost]
        public IActionResult AdicionarManutencao([FromBody] Manutencao manutencao)
        {
            var placa = _manutencaoService.AdicionarManutencaoService(manutencao);
            return Ok(placa);
        }

        [HttpGet]
        public IActionResult EncontrarManutencao()
        {
            return Ok(_manutencaoService.ListarManutencao());
        }

        [HttpGet("{id}")]
        public IActionResult ObterManutencaoPorId(int id)
        {
            var manutencao = _manutencaoService.ObterManutencaoPorId(id);
            if (manutencao.Sucesso)
            {
                return Ok(manutencao);
            }
            return NotFound();
        }

        [HttpPut("{placa}")]
        public IActionResult AtualizarManutencao(int id, Manutencao manutencaoAtualizado)
        {
            var manutencao = _manutencaoService.AtualizarManutencao(id, manutencaoAtualizado);
            if (manutencao.Sucesso)
            {
                return Ok(manutencao);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverManutencao(int id)
        {

            var manutencao = _manutencaoService.RemoverManutencao(id);
            if (manutencao.Sucesso)
            {
                return Ok(manutencao);
            }
            return NoContent();
        }

    }

}
