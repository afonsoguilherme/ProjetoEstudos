using projetoAPI.DataAccess.DTO;
using projetoAPI.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace projetoAPI.DataAccess.DAO
{
    public interface IFuncionarioDAO
    {
        //TABELA FUNCIONARIO
        List<FuncionarioDTO> ObterTodosFuncionarios();
        FuncionarioDTO ObterFuncionariosPorId(string idFuncionario);
        FuncionarioDTO ObterFuncionariosPorNome(string nomeFuncionario);
        void AdcionarNovoFuncionario(FuncionarioDTO funcionario);
        void AtualizarFuncionario(string idFuncionario, FuncionarioDTO funcionarioNew);
        void DeletarFuncionario(string idFuncionario);
    }

}
