using API_Gasolina.Data.ValueObjects;
using API_Gasolina.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Gasolina.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoController(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository ?? throw new
                ArgumentNullException(nameof(avaliacaoRepository));
        }

        [HttpGet("RetornarTodos")]
        public async Task<ActionResult<IEnumerable<AvaliacaoVO>>> FindAll()
        {
            var avaliacoes = await _avaliacaoRepository.FindAll();
            return Ok(avaliacoes);
        }

        [HttpGet("{idUsuarioTelegram}")]
        public async Task<ActionResult<AvaliacaoVO>> FindById(string idUsuarioTelegram)
        {
            var avaliacao = await _avaliacaoRepository.FindById(idUsuarioTelegram);
            if (avaliacao == null) return NotFound();
            return Ok(new { status = StatusCodes.Status200OK, data = avaliacao, date = DateTime.Now });
        }

        [HttpPost]
        public async Task<ActionResult<AvaliacaoVO>> Create(AvaliacaoVO avaliacaoVO)
        {
            if (avaliacaoVO == null) return BadRequest();
            var avaliacao = await _avaliacaoRepository.Create(avaliacaoVO);
            return Ok(avaliacao);
        }
    }
}
