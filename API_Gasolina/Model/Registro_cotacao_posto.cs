using API_Gasolina.GasolinaAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Gasolina.Model
{
    [Table("registro_cotacao_posto")]
    public class Registro_cotacao_posto : BaseEntity
    {
        [Column("data_cotacao")]
        public string? Data_cotacao { get; set; }

        [Column("cnpj")]
        public string? Cnpj { get; set; }

        [Column("nome_fantasia")]
        public string? Nome_fantasia { get; set; }

        [Column("nome_rua")]
        public string? Nome_rua { get; set; }

        [Column("numero_rua")]
        public string? Numero_rua { get; set; }

        [Column("complemento_endereco")]
        public string? Complemento_endereco { get; set; }

        [Column("bairro_endereco")]
        public string? Bairro_endereco { get; set; }

        [Column("cep_endereco")]
        public int Cep_endereco { get; set; }

        [Column("municipio_endereco")]
        public string? Municipio_endereco { get; set; }

        [Column("estado_endereco")]
        public string? Estado_endereco { get; set; }

        [Column("bandeira_posto")]
        public string? Bandeira_posto { get; set; }

        [Column("nome_produto")]
        public string? Nome_produto { get; set; }

        [Column("cotacao_produto_posto")]
        public double Cotacao_produto_posto { get; set; }
    }
}
