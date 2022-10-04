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
    public class RegistroController : ControllerBase
    {
        private IRegistroRepository _registroRepository;

        public RegistroController(IRegistroRepository registroRepository)
        {
            _registroRepository = registroRepository ?? throw new 
                ArgumentNullException(nameof(registroRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroVO>>> FindAll() {
            var registros = await _registroRepository.FindAll();            
            return Ok(registros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroVO>> FindById(int id)
        {
            var registro = await _registroRepository.FindById(id);
            if (registro == null) return NotFound();
            return Ok(registro);
        }

        [HttpGet("{estado}/{municipio}/{produto}")]
        public async Task<ActionResult<RegistroVO>> FindPrecoEstadoMunicipioProduto(string estado, string municipio, string produto)
        {
            var registro = await _registroRepository.FindPrecoEstadoMunicipioProduto(estado, municipio, produto);
            if (registro == null) return NotFound();
            return Ok(registro);
        }
    }
}
