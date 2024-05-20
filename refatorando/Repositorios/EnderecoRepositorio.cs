using Microsoft.EntityFrameworkCore;
using refatorando.Data;
using refatorando.Model;
using refatorando.Repositorios.Interfaces;

namespace refatorando.Repositorios
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly SistemaDataBaseContext _dbcontext;
        public EnderecoRepositorio(SistemaDataBaseContext dataBaseContext)
        {
            _dbcontext = dataBaseContext;
        }
        public async Task<EnderecoModel> BuscarPorId(int id)
        {
            return await _dbcontext.tbendereco.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<EnderecoModel>> BuscarTodosEnderecos()
        {
            return await _dbcontext.tbendereco.ToListAsync();
        }
        public async Task<EnderecoModel> Adicionar(EnderecoModel endereco)
        {
            await _dbcontext.tbendereco.AddAsync(endereco);
            await _dbcontext.SaveChangesAsync();

            return endereco;
        }
        public async Task<EnderecoModel> Atualizar(EnderecoModel endereco, int id)
        {
            EnderecoModel enderecoPorId = await BuscarPorId(id);
            if (enderecoPorId == null)
            {
                throw new Exception($"Endereço para o ID: {id} não foi encontrado no banco de dados.");
            }
            enderecoPorId.CEP = endereco.CEP;
            enderecoPorId.Rua = endereco.Rua;
            enderecoPorId.Cidade = endereco.Cidade;
            enderecoPorId.Estado = endereco.Estado;

            _dbcontext.tbendereco.Update(enderecoPorId);
            await _dbcontext.SaveChangesAsync();

            return enderecoPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            EnderecoModel enderecoPorId = await BuscarPorId(id);
            if (enderecoPorId == null)
            {
                throw new Exception($"endereco por ID: {id} não foi encontrado no banco de dados.");
            }

            _dbcontext.tbendereco.Remove(enderecoPorId);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
