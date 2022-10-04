using API_Gasolina.Data.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Gasolina.Repository
{
    public interface IRegistroRepository
    {
        Task<IEnumerable<RegistroVO>> FindAll();
        Task<RegistroVO> FindById(int id);
        Task<RegistroVO> FindPrecoEstadoMunicipioProduto(string estado, string municipio, string produto);
    }
}
