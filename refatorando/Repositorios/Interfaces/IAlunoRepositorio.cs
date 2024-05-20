﻿using refatorando.Model;

namespace refatorando.Repositorios.Interfaces
{
    public interface IAlunoRepositorio
    {
        Task<List<AlunoModel>> BuscarTodosAlunos();
        Task<AlunoModel> BuscarPorId(int id);
        Task<AlunoModel> Adicionar(AlunoModel aluno);
        Task<AlunoModel> Atualizar(AlunoModel aluno, int id);
        Task<bool> Apagar(int id);
    }
}
