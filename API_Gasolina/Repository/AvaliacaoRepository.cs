using API_Gasolina.Data.ValueObjects;
using API_Gasolina.GasolinaAPI.Model;
using API_Gasolina.GasolinaAPI.Model.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Gasolina.Repository
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public AvaliacaoRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AvaliacaoVO> Create(AvaliacaoVO avaliacaoVO)
        {
            Avaliacao avaliacao = _mapper.Map<Avaliacao>(avaliacaoVO);
            _context.Avaliacao.Add(avaliacao);
            await _context.SaveChangesAsync();
            return _mapper.Map<AvaliacaoVO>(avaliacao);
        }

        public async Task<IEnumerable<AvaliacaoVO>> FindAll()
        {
            List<Avaliacao> registro = await _context.Avaliacao.ToListAsync();
            return _mapper.Map<List<AvaliacaoVO>>(registro);
        }

        public async Task<AvaliacaoVO> FindById(string idUsuario)
        {
            Avaliacao registro =
                await _context.Avaliacao.Where(r => r.IdUsuarioTelegram == idUsuario)
                .FirstOrDefaultAsync();
            return _mapper.Map<AvaliacaoVO>(registro);
        }
    }
}
