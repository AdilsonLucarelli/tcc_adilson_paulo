using API_Gasolina.GasolinaAPI.Model.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Gasolina.GasolinaAPI.Model
{
    [Table("registro_cotacao")]
    public class Registro_cotacao : BaseEntity
    {
        [Column("data")]
        public string Data { get; set; }

        [Column("estado")]        
        public string Estado { get; set; }

        [Column("municipio")]        
        public string Municipio { get; set; }

        [Column("produto")]        
        public string Produto { get; set; }

        [Column("numero_de_postos_pesquisados")]       
        public int Numero_de_postos_pesquisados { get; set; }

        [Column("preco_medio_revenda")]
        public double Preco_medio_revenda { get; set; }

        [Column("preco_minimo_revenda")]
        public double Preco_minimo_revenda { get; set; }

        [Column("preco_maximo_revenda")]
        public double Preco_maximo_revenda { get; set; }
    }
}
