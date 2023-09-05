namespace senai.inlock.webApi.Domain
{
    public class JogoDomain
    {
        public int IdJogo{ get; set; }

        public int IdEstudio{ get; set; }

        public string? Nome{ get; set; }

        public string? Descricao{ get; set; }

        public DateTime DataLançamento { get; set; }

        public string? Valor { get; set; }
    }
}
