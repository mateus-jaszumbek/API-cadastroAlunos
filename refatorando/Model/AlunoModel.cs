using refatorando.Enum;

namespace refatorando.Model
{
    public class AlunoModel
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public TipoEndereco TipoEnderec { get; set; }
        public virtual EnderecoModel? Endereco { get; set; }
        public SerieAluno Serie { get; set; }
        public SegmentoAluno Segmento { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public int? EnderecoId { get; set; }
        
        public string DataNascimentoFormatada => DataNascimento.ToString("yyyy-MM-dd");
    }

}


