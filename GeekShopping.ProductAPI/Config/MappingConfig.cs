using API_Gasolina.Data.ValueObjects;
using API_Gasolina.GasolinaAPI.Model;
using API_Gasolina.Model;
using AutoMapper;
using System.Net.NetworkInformation;

namespace API_Gasolina.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<RegistroVO, Registro_cotacao>();
                config.CreateMap<Registro_cotacao, RegistroVO>();

                config.CreateMap<AvaliacaoVO, Avaliacao>();
                config.CreateMap<Avaliacao, AvaliacaoVO>();

                config.CreateMap<CotacaoPostoVO, Registro_cotacao_posto>();
                config.CreateMap<Registro_cotacao_posto, CotacaoPostoVO>();
            });
            return mappingConfig;
        }
    }
}
