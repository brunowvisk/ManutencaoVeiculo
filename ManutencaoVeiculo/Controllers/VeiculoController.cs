using ManutencaoVeiculo.Application.Interfaces;
using ManutencaoVeiculo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ManutencaoVeiculo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;
        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpPost]
        public IActionResult AdicionarVeiculo([FromBody] Veiculo veiculo)
        {
            var car = _veiculoService.AdicionarVeiculo(veiculo);
            return Ok(car);
        }

        [HttpGet]
        public IActionResult EncontraVeiculos()
        {
            return Ok(_veiculoService.ListarVeiculos());
        }

        [HttpGet("{placa}")]
        public IActionResult ObterVeiculoPorPlaca(string placa)
        {
            var car = _veiculoService.ObterVeiculoPorPlaca(placa);
            if (car.Sucesso)
            {
                return Ok(car);
            }
            return NotFound();
        }

        [HttpPut("{placa}")]
        public IActionResult AtualizarVeiculo(string placa, Veiculo veiculoatualizado)
        {
            var car = _veiculoService.AtualizarVeiculo(placa, veiculoatualizado);
            if (car.Sucesso)
            {
                return Ok(car);
            }
            return NotFound();
        }

        [HttpDelete("{placa}")]
        public IActionResult RemoverVeiculo(string placa)
        {

            var car = _veiculoService.RemoverVeiculo(placa);
            if (car.Sucesso)
            {
                return Ok(car);
            }
            return NoContent();
        }

    }
}
