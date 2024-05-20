using Microsoft.AspNetCore.Mvc;
using refatorando.Model;
using refatorando.Repositorios.Interfaces;

namespace refatorando.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public EnderecoController(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<EnderecoModel>>> BuscarTodosEnderecos()
        {
            List<EnderecoModel> enderecos = await _enderecoRepositorio.BuscarTodosEnderecos();
            return Ok(enderecos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoModel>> BuscarPorId(int id)
        {
            EnderecoModel endereco = await _enderecoRepositorio.BuscarPorId(id);
            return Ok(endereco);
        }
        [HttpPost]
        public async Task<ActionResult<EnderecoModel>> Cadastrar([FromBody] EnderecoModel enderecoModel)
        {
            EnderecoModel endereco = await _enderecoRepositorio.Adicionar(enderecoModel);

            return Ok(endereco);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<EnderecoModel>> Atualizar([FromBody] EnderecoModel enderecoModel, int id)
        {
            enderecoModel.Id = id;
            EnderecoModel endereco = await _enderecoRepositorio.Atualizar(enderecoModel, id);
            return Ok(endereco);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<EnderecoModel>> Apagar(int id)
        {
            bool apagado = await _enderecoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
