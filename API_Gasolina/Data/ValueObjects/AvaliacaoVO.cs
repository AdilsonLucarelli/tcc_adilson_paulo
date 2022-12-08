using System.ComponentModel.DataAnnotations.Schema;

namespace API_Gasolina.Data.ValueObjects
{
    public class AvaliacaoVO
    {
        public long Id { get; set; }
        public string? IdUsuarioTelegram { get; set; }

        public string? Data { get; set; }

        public int Nota { get; set; }

        public string? Descricao { get; set; }
    }
}
