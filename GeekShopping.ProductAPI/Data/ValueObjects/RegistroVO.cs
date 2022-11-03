namespace API_Gasolina.Data.ValueObjects
{
    public class RegistroVO
    {
        public long Id { get; set; }
        public string Data { get; set; }

        public string Estado { get; set; }

        public string Municipio { get; set; }

        public string Produto { get; set; }

        public double Average { get; set; }

        public int Numero_de_postos_pesquisados { get; set; }

        public double Preco_medio_revenda { get; set; }

        public double Preco_minimo_revenda { get; set; }

        public double Preco_maximo_revenda { get; set; }
    }
}
