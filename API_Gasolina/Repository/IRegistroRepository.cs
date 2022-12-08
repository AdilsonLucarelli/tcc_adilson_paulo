using API_Gasolina.Data.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Gasolina.Repository
{
    public interface IRegistroRepository
    {
        Task<IEnumerable<RegistroVO>> FindAll();
        Task<IEnumerable<RegistroVO>> FindAllOrderByEstado();
        Task<IEnumerable<RegistroVO>> FindAllOrderByProduto();
        Task<IEnumerable<RegistroVO>> FindAllOrderByMunicipio();
        Task<RegistroVO> FindById(int id);
        Task<RegistroVO> FindPrecoEstadoMunicipioProduto(string estado, string municipio, string produto);
        Task<IEnumerable<RegistroVO>> FindPrecosPorEstados(string produto);
        Task<IEnumerable<RegistroVO>> FindAllPrecosPorEstado(string estado, string produto);
        Task<IEnumerable<RegistroVO>> FindAllPrecosPorMunicipio(string municipio, string produto);
        Task<IEnumerable<RegistroVO>> FindAllPrecosPorProduto(string produto);
        Task<IEnumerable<RegistroVO>> PrecoMediaASCPorProduto(string produto);
        Task<IEnumerable<RegistroVO>> PrecoMediaASCPorMunicipio(string produto);
    }
}
