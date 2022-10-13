using API_Gasolina.Data.ValueObjects;
using API_Gasolina.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Gasolina.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CotacaoPostoController : ControllerBase
    {
        private ICotacaoPostoRepository _cotacaoPostoRepository;

        public CotacaoPostoController(ICotacaoPostoRepository cotacaoPostoRepository)
        {
            _cotacaoPostoRepository = cotacaoPostoRepository ?? throw new
                ArgumentNullException(nameof(cotacaoPostoRepository));
        }

        [HttpGet("RetornarTodos")]
        public async Task<ActionResult<IEnumerable<CotacaoPostoVO>>> FindAll()
        {
            var registros = await _cotacaoPostoRepository.FindAll();
            return Ok(registros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CotacaoPostoVO>> FindById(int id)
        {
            var registro = await _cotacaoPostoRepository.FindById(id);
            if (registro == null) return NotFound();
            return Ok(registro);
        }
    }
}
