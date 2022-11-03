using API_Gasolina.Data.ValueObjects;
using API_Gasolina.GasolinaAPI.Model;
using API_Gasolina.GasolinaAPI.Model.Context;
using API_Gasolina.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Gasolina.Repository
{
    public class CotacaoPostoRepository : ICotacaoPostoRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;
        public CotacaoPostoRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CotacaoPostoVO>> FindAll()
        {
            List<Registro_cotacao_posto> registro = await _context.CotacaoPosto.ToListAsync();
            return _mapper.Map<List<CotacaoPostoVO>>(registro);
        }

        public async Task<CotacaoPostoVO> FindById(int id)
        {
            Registro_cotacao_posto registro =
                await _context.CotacaoPosto.Where(r => r.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<CotacaoPostoVO>(registro);
        }

        public async Task<IEnumerable<CotacaoPostoVO>> PostosMaisBaratosPorMunicipio(string produto, string municipio)
        {
            List<Registro_cotacao_posto> registro = await _context.CotacaoPosto.Where(r => r.Municipio_endereco == municipio && r.Nome_produto == produto).OrderBy(r => r.Cotacao_produto_posto).Take(3).ToListAsync();
            if (registro.Count == 0) return null;
            return _mapper.Map<List<CotacaoPostoVO>>(registro);
        }
    }
}
