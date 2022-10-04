using API_Gasolina.Data.ValueObjects;
using API_Gasolina.GasolinaAPI.Model;
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
            });
            return mappingConfig;
        }
    }
}
