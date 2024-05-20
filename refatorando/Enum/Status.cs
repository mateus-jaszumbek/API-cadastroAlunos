using System.ComponentModel;

namespace refatorando.Enum
{
    public enum TipoEndereco
    {
        Cobranca = 1,
        Residencial = 2,
        Correspondencia = 3
    }
    public enum SegmentoAluno
    {
        [Description("G1 ao G3")]
        Infantil = 1, // G1 ao G3
        [Description("1º ao 5º ano")]
        AnosIniciais = 2, // 1º ao 5º ano
        [Description("6º ao 9º ano")]
        AnosFinais = 3, // 6º ao 9º ano
        [Description("1º ao 3º ano ensino médio")]
        EnsinoMedio = 4 // 1º ao 3º ano ensino médio
    }    
    public enum SerieAluno
    {
        G1 = 1, // Alunos entre 3 anos
        G2 = 2, // Alunos entre 4 anos
        G3 = 3, // Alunos entre 5 anos
        PrimeiroAno = 4, // 1º ano: Alunos entre 6 anos
        SegundoAno = 5, // 2º ano: Alunos entre 7 anos
        TerceiroAno = 6, // 3º ano: Alunos entre 8 anos
        QuartoAno = 7, // 4º ano: Alunos entre 9 anos
        QuintoAno = 8, // 5º ano: Alunos entre 10 anos
        SextoAno = 9, // 6º ano: Alunos entre 11 anos
        SetimoAno = 10, // 7º ano: Alunos entre 12 anos
        OitavoAno = 11, // 8º ano: Alunos entre 13 anos
        NonoAno = 12, // 9º ano: Alunos entre 14 anos
        PrimeiroAnoEM = 13, // 1º ano ensino médio: Alunos entre 15 anos
        SegundoAnoEM = 14, // 2º ano ensino médio: Alunos entre 16 anos
        TerceiroAnoEM = 15 // 3º ano ensino médio: Alunos entre 17 anos
    }
}
