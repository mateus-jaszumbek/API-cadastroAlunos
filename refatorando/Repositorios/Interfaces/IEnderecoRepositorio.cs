using refatorando.Model;

namespace refatorando.Repositorios.Interfaces
{
    public interface IEnderecoRepositorio
    {
        Task<List<EnderecoModel>> BuscarTodosEnderecos();
        Task<EnderecoModel> BuscarPorId(int id);
        Task<EnderecoModel> Adicionar(EnderecoModel endereco);
        Task<EnderecoModel> Atualizar(EnderecoModel endereco, int id);
        Task<bool> Apagar(int id);
    }
}
