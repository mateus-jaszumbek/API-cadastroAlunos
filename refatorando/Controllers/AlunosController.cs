using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using refatorando.Model;
using refatorando.Repositorios.Interfaces;

namespace refatorando.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunosController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<AlunoModel>>> BuscarTodosUsuarios()
        {
            List<AlunoModel> alunos = await _alunoRepositorio.BuscarTodosAlunos();
            return Ok(alunos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoModel>> BuscarPorId(int id)
        {
            AlunoModel aluno = await _alunoRepositorio.BuscarPorId(id);
            return Ok(aluno);
        }
        [HttpPost]
        public async Task<ActionResult<AlunoModel>> Cadastrar([FromBody] AlunoModel alunoModel)
        {
            AlunoModel aluno = await _alunoRepositorio.Adicionar(alunoModel);

            return Ok(aluno);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<AlunoModel>> Atualizar([FromBody] AlunoModel alunoModel, int id)
        {
            alunoModel.Id = id;
            AlunoModel aluno = await _alunoRepositorio.Atualizar(alunoModel, id);
            return Ok(aluno);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlunoModel>> Apagar(int id)
        {
            bool apagado = await _alunoRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
