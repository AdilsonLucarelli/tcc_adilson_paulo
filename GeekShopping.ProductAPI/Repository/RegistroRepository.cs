using API_Gasolina.Data.ValueObjects;
using API_Gasolina.GasolinaAPI.Model;
using API_Gasolina.GasolinaAPI.Model.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
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
    }
}
