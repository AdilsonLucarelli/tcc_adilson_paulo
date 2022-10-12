using API_Gasolina.Data.ValueObjects;
using API_Gasolina.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("RetornarTodos")]
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

        [HttpGet("RetornarFiltrado/{estado}/{municipio}/{produto}")]
        public async Task<ActionResult<RegistroVO>> FindPrecoEstadoMunicipioProduto(string estado, string municipio, string produto)
        {
            var registro = await _registroRepository.FindPrecoEstadoMunicipioProduto(estado, municipio, produto);
            if (registro == null) return NotFound();
            return Ok(registro);
        }

        [HttpGet("RetornarProdutos")]
        public async Task<ActionResult<RegistroVO>> FindProdutos()
        {
            var registro = await _registroRepository.FindAll();
            var produtos = registro.Select(r => r.Produto).Distinct();
            return Ok(produtos);
        }

        [HttpGet("RetornarEstados")]
        public async Task<ActionResult<RegistroVO>> FindEstados()
        {
            var registro = await _registroRepository.FindAll();
            var estados = registro.Select(r => r.Estado).Distinct();
            return Ok(estados);
        }

        [HttpGet("RetornarMunicipios")]
        public async Task<ActionResult<RegistroVO>> FindMunicipios()
        {
            var registro = await _registroRepository.FindAll();
            var municipios = registro.Select(r => r.Municipio).Distinct(); //Select(r => new { r.Municipio, r.Data })
            return Ok(municipios);
        }

        [HttpGet("RetornarPrecosPorEstados/{produto}")]
        public async Task<ActionResult<RegistroVO>> FindPrecosPorEstados(string produto)
        {
            var registro = await _registroRepository.FindPrecosPorEstados(produto);
            return Ok(registro);
        }

        [HttpGet("RetornarTodosPrecosPorEstado/{estado}")]
        public async Task<ActionResult<RegistroVO>> FindAllPrecosPorEstado(string estado)
        {
            var registro = await _registroRepository.FindAllPrecosPorEstado(estado);
            return Ok(registro);
        }

        [HttpGet("RetornarTodosPrecosPorMunicipio/{municipio}")]
        public async Task<ActionResult<RegistroVO>> FindAllPrecosPorMunicipio(string municipio)
        {
            var registro = await _registroRepository.FindAllPrecosPorMunicipio(municipio);
            return Ok(registro);
        }

        [HttpGet("RetornarTodosPrecosPorCombustivel/{produto}")]
        public async Task<ActionResult<RegistroVO>> FindAllPrecosPorProduto(string produto)
        {
            var registro = await _registroRepository.FindAllPrecosPorProduto(produto);
            return Ok(registro);
        }
    }
}