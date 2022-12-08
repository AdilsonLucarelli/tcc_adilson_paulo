using API_Gasolina.GasolinaAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Gasolina.GasolinaAPI.Model
{
    [Table("avaliacao")]
    public class Avaliacao : BaseEntity
    {
        [Column("idusuariotelegram")]
        public string? IdUsuarioTelegram { get; set; }

        [Column("data")]
        public string? Data { get; set; }

        [Column("nota")]
        public int Nota { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }
    }
}
