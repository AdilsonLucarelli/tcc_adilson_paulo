using API_Gasolina.Data.ValueObjects;
using API_Gasolina.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("PostosMaisBaratosPorMunicipio/{produto}/{municipio}")]
        public async Task<ActionResult<CotacaoPostoVO>> PostosMaisBaratosPorMunicipio(string produto, string municipio)
        {
            var registro = await _cotacaoPostoRepository.PostosMaisBaratosPorMunicipio(produto, municipio);
            if (registro == null) return NotFound();
            return Ok(new { status = StatusCodes.Status200OK, data = registro, date = DateTime.Now });
        }

        [HttpGet("RetornarProdutos")]
        public async Task<ActionResult<CotacaoPostoVO>> FindProdutos()
        {
            var registro = await _cotacaoPostoRepository.FindAll();
            var produtos = registro.Select(r => r.Nome_produto).Distinct();
            return Ok(new { status = StatusCodes.Status200OK, data = produtos, date = DateTime.Now });
        }

        [HttpGet("RetornarMunicipios")]
        public async Task<ActionResult<CotacaoPostoVO>> FindMunicipios()
        {
            var registro = await _cotacaoPostoRepository.FindAll();
            var municipios = registro.Select(r => r.Municipio_endereco).Distinct();
            return Ok(new { status = StatusCodes.Status200OK, data = municipios, date = DateTime.Now });
        }
    }
}
