using API_Gasolina.Data.ValueObjects;
using API_Gasolina.GasolinaAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Gasolina.Repository
{
    public interface IAvaliacaoRepository
    {
        Task<IEnumerable<AvaliacaoVO>> FindAll();
        Task<AvaliacaoVO> FindById(string id);
        Task<AvaliacaoVO> Create(AvaliacaoVO avaliacao);
    }
}
