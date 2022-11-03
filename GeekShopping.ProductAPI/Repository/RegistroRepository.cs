using API_Gasolina.Data.ValueObjects;
using API_Gasolina.GasolinaAPI.Model;
using API_Gasolina.GasolinaAPI.Model.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Gasolina.Repository
{
    public class RegistroRepository : IRegistroRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;
        public RegistroRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RegistroVO>> FindAll()
        {
            List<Registro_cotacao> registro = await _context.Registro.ToListAsync();
            return _mapper.Map<List<RegistroVO>>(registro);
        }

        public async Task<IEnumerable<RegistroVO>> FindAllOrderByEstado()
        {
            List<Registro_cotacao> registro = await _context.Registro.OrderBy(r => r.Estado).ToListAsync();
            return _mapper.Map<List<RegistroVO>>(registro);
        }

        public async Task<IEnumerable<RegistroVO>> FindAllOrderByProduto()
        {
            List<Registro_cotacao> registro = await _context.Registro.OrderBy(r => r.Produto).ToListAsync();
            return _mapper.Map<List<RegistroVO>>(registro);
        }

        public async Task<IEnumerable<RegistroVO>> FindAllOrderByMunicipio()
        {
            List<Registro_cotacao> registro = await _context.Registro.OrderBy(r => r.Municipio).ToListAsync();
            return _mapper.Map<List<RegistroVO>>(registro);
        }

        public async Task<RegistroVO> FindById(int id)
        {
            Registro_cotacao registro =
                await _context.Registro.Where(r => r.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<RegistroVO>(registro);
        }

        public async Task<RegistroVO> FindPrecoEstadoMunicipioProduto(string estado, string municipio, string produto)
        {
            Registro_cotacao registro =
                await _context.Registro.Where(r => r.Estado == estado && r.Municipio == municipio && r.Produto == produto)
                .FirstOrDefaultAsync();
            return _mapper.Map<RegistroVO>(registro);
        }

        public async Task<IEnumerable<RegistroVO>> FindPrecosPorEstados(string produto)
        {
            List<Registro_cotacao> registro = await _context.Registro.Where(r => r.Produto == produto && r.Data == "2022-10-22").ToListAsync();
            if (registro.Count == 0) return null;
            return _mapper.Map<List<RegistroVO>>(registro);
        }

        public async Task<IEnumerable<RegistroVO>> FindAllPrecosPorEstado(string estado, string produto)
        {
            List<Registro_cotacao> registro = await _context.Registro.Where(r => r.Estado == estado && r.Produto == produto && r.Data == "2022-10-22").ToListAsync();
            if (registro.Count == 0) return null;
            return _mapper.Map<List<RegistroVO>>(registro);
        }

        public async Task<IEnumerable<RegistroVO>> FindAllPrecosPorMunicipio(string municipio, string produto)
        {
            List<Registro_cotacao> registro = await _context.Registro.Where(r => r.Municipio == municipio && r.Produto == produto && r.Data == "2022-10-22").ToListAsync();
            if (registro.Count == 0) return null;
            return _mapper.Map<List<RegistroVO>>(registro);
        }

        public async Task<IEnumerable<RegistroVO>> FindAllPrecosPorProduto(string produto)
        {
            List<Registro_cotacao> registro = await _context.Registro.Where(r => r.Produto == produto).ToListAsync();
            if (registro.Count == 0) return null;
            return _mapper.Map<List<RegistroVO>>(registro);
        }

        public async Task<IEnumerable<RegistroVO>> PrecoMediaASCPorProduto(string produto)
        {
            List<Registro_cotacao> registro = await _context.Registro.Where(r => r.Produto == produto && r.Data == "2022-10-22").OrderBy(r => r.Preco_medio_revenda).Take(3).ToListAsync();
            if (registro.Count == 0) return null;
            return _mapper.Map<List<RegistroVO>>(registro);
        }

        public async Task<IEnumerable<RegistroVO>> PrecoMediaASCPorMunicipio(string municipio)
        {
            List<Registro_cotacao> registro = await _context.Registro.Where(r => r.Municipio == municipio && r.Data == "2022-10-22").OrderBy(r => r.Preco_medio_revenda).Take(3).ToListAsync();
            if (registro.Count == 0) return null;
            return _mapper.Map<List<RegistroVO>>(registro);
        }        
    }
}
