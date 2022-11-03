using API_Gasolina.Data.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Gasolina.Repository
{
    public interface ICotacaoPostoRepository
    {
        Task<IEnumerable<CotacaoPostoVO>> FindAll();
        Task<IEnumerable<CotacaoPostoVO>> FindAllOrderByMunicipio();
        Task<IEnumerable<CotacaoPostoVO>> FindAllOrderByProduto();
        Task<CotacaoPostoVO> FindById(int id);
        Task<IEnumerable<CotacaoPostoVO>> PostosMaisBaratosPorMunicipio(string produto, string municipio);
    }
}
