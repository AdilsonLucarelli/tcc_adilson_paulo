using System.ComponentModel.DataAnnotations.Schema;

namespace API_Gasolina.Data.ValueObjects
{
    public class CotacaoPostoVO
    {
        public long Id { get; set; }
        public string Data_cotacao { get; set; }
        
        public string Cnpj { get; set; }
        
        public string Nome_fantasia { get; set; }
        
        public string Nome_rua { get; set; }
        
        public string Numero_rua { get; set; }
        
        public string Complemento_endereco { get; set; }
        
        public string Bairro_endereco { get; set; }
        
        public int Cep_endereco { get; set; }
        
        public string Municipio_endereco { get; set; }
        
        public string Estado_endereco { get; set; }
        
        public string Bandeira_posto { get; set; }
        
        public string Nome_produto { get; set; }

        public double Cotacao_produto_posto { get; set; }
    }
}
