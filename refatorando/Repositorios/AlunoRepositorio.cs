using Microsoft.EntityFrameworkCore;
using refatorando.Data;
using refatorando.Enum;
using refatorando.Model;
using refatorando.Repositorios.Interfaces;

namespace refatorando.Repositorios
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly SistemaDataBaseContext _dbcontext;
        private static readonly Random _random = new Random();
        public AlunoRepositorio(SistemaDataBaseContext dataBaseContext)
        {
            _dbcontext = dataBaseContext;
        }
        public async Task<AlunoModel> BuscarPorId(int id)
        {
            return await _dbcontext.tbalunos
                .Include(x => x.Endereco)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AlunoModel>> BuscarTodosAlunos()
        {
            return await _dbcontext.tbalunos
                 .Include(x => x.Endereco)
                .ToListAsync();
        }
        public async Task<AlunoModel> Adicionar(AlunoModel aluno)
        {
            aluno.Matricula = await GerarMatriculaUnicaAsync();
            DefinirSegmentoESerie(aluno);
            await _dbcontext.tbalunos.AddAsync(aluno);
            await _dbcontext.SaveChangesAsync();

            return aluno;
        }
        public async Task<AlunoModel> Atualizar(AlunoModel aluno, int id)
        {
            AlunoModel alunoPorId = await BuscarPorId(id);
            if (alunoPorId == null)
            {
                throw new Exception($"Aluno por ID: {id} não foi encontrado no banco de dados.");
            }
            alunoPorId.Nome = aluno.Nome;
            alunoPorId.Segmento = aluno.Segmento;
            alunoPorId.Serie = aluno.Serie;
            alunoPorId.TipoEnderec = aluno.TipoEnderec;
            alunoPorId.NomePai = aluno.NomePai;
            alunoPorId.NomeMae = aluno.NomeMae;
            alunoPorId.DataNascimento = aluno.DataNascimento;
            alunoPorId.EnderecoId = aluno.EnderecoId;
            DefinirSegmentoESerie(alunoPorId);
            _dbcontext.tbalunos.Update(alunoPorId);
            await _dbcontext.SaveChangesAsync();

            return alunoPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            AlunoModel alunoPorId = await BuscarPorId(id);
            if (alunoPorId == null)
            {
                throw new Exception($"Aluno por ID: {id} não foi encontrado no banco de dados.");
            }

            _dbcontext.tbalunos.Remove(alunoPorId);
            await _dbcontext.SaveChangesAsync();
            return true;
        }




        private async Task<int> GerarMatriculaUnicaAsync()
        {
            int matricula;
            bool existe;

            do
            {
                matricula = GerarMatriculaAleatoria();
                existe = await _dbcontext.tbalunos.AnyAsync(a => a.Matricula == matricula);
            } while (existe);

            return matricula;
        }
        private int GerarMatriculaAleatoria()
        {
            lock (_random)
            {
                return _random.Next(10000000, 99999999);
            }
        }
        private void DefinirSegmentoESerie(AlunoModel aluno)
        {
            int idade = CalcularIdade(aluno.DataNascimento);

            if (idade >= 3 && idade <= 5)
            {
                aluno.Segmento = SegmentoAluno.Infantil;
                aluno.Serie = (SerieAluno)(idade - 2); // G1 = 1, G2 = 2, G3 = 3
            }
            else if (idade >= 6 && idade <= 10)
            {
                aluno.Segmento = SegmentoAluno.AnosIniciais;
                aluno.Serie = (SerieAluno)(idade + 1); // PrimeiroAno = 4, ..., QuintoAno = 8
            }
            else if (idade >= 11 && idade <= 14)
            {
                aluno.Segmento = SegmentoAluno.AnosFinais;
                aluno.Serie = (SerieAluno)(idade - 2); // SextoAno = 9, ..., NonoAno = 12
            }
            else if (idade >= 15 && idade <= 17)
            {
                aluno.Segmento = SegmentoAluno.EnsinoMedio;
                aluno.Serie = (SerieAluno)(idade - 2); // PrimeiroAnoEM = 13, ..., TerceiroAnoEM = 15
            }
            else
            {
                throw new Exception("Idade fora do intervalo esperado para alunos.");
            }
        }
        private int CalcularIdade(DateTime dataNascimento)
        {
            var today = DateTime.Today;
            var age = today.Year - dataNascimento.Year;
            if (dataNascimento.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
