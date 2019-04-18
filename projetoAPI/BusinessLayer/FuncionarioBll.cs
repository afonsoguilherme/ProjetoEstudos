using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetoAPI.DataAccess.DTO;
using projetoAPI.DataAccess.DAO;
using projetoAPI.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace projetoAPI.BusinessLayer
{
    public class FuncionarioBll : IFuncionarioBll
    {   
        //VERIFICAÇÃO DE TESTES UNITARIOS
        public string Teste = "teste";
        public readonly IFuncionarioDAO _funcionarioDAO;

        //INJEÇÃO DE DEPENDENCIAS
        public FuncionarioBll(IFuncionarioDAO funcionarioDAO)
        {
            _funcionarioDAO = funcionarioDAO;
        }

        //OBTEM OS FUNCIONARIOS DE ACORDO COM AS REGRAS DE NEGOCIO
        //CHAMA A FUNÇÃO DE ACESSO DE DADOS, FUNCIONARIODAO-ObterTodosFUNCIONARIOs
        public List<FuncionarioDTO> ObterTodosFuncionarios()
        {
            var verifica = _funcionarioDAO.ObterTodosFuncionarios();

            if(verifica == null){ return null; }
            
            this.Teste = "Metodo executado corretamente";
            return verifica;
        } 

        //OBTEM OS FUNCIONARIOS DE ACORDO COM AS REGRAS DE NEGOCIO
        //CHAMA A FUNÇÃO DE ACESSO DE DADOS, FUNCIONARIODAO-ObterFUNCIONARIOsPorId
        public FuncionarioDTO ObterFuncionariosPorId(string idFuncionario)
        {
            if((idFuncionario != null)&&(idFuncionario != ""))
            {
               return _funcionarioDAO.ObterFuncionariosPorId(idFuncionario); 
            }
            return null;
        }

        //OBTEM OS FUNCIONARIOS DE ACORDO COM AS REGRAS DE NEGOCIO
        //CHAMA A FUNÇÃO DE ACESSO DE DADOS, FUNCIONARIODAO-ObterFUNCIONARIOsPorNOME
        public FuncionarioDTO ObterFuncionariosPorNome(string nomeFuncionario)
        {
            if((nomeFuncionario != null)&&(nomeFuncionario != ""))
            {
               return _funcionarioDAO.ObterFuncionariosPorNome(nomeFuncionario); 
            }
            return null;
        }

        //OBTEM OS FUNCIONARIOS DE ACORDO COM AS REGRAS DE NEGOCIO
        //CHAMA A FUNÇÃO DE ACESSO DE DADOS, FUNCIONARIODAO-AdicionarNovoFUNCIONARIO
        public void AdcionarNovoFuncionario(FuncionarioDTO funcionario)
        {
            if((funcionario != null)&&(funcionario.NomeFuncionario != null))
            {
                _funcionarioDAO.AdcionarNovoFuncionario(funcionario);
            }
            this.Teste = "Falha na execucao do metodo";
        }

        //OBTEM OS FUNCIONARIOS DE ACORDO COM AS REGRAS DE NEGOCIO
        //CHAMA A FUNÇÃO DE ACESSO DE DADOS, FUNCIONARIODAO-AtualizarFUNCIONARIO
        public void AtualizarFuncionario(string idFuncionario, FuncionarioDTO funcionarioNew)
        {
            if((idFuncionario != null)&&(funcionarioNew != null))
            {
                _funcionarioDAO.AtualizarFuncionario(idFuncionario, funcionarioNew);
            }
            this.Teste = "Falha na execucao do metodo";
        }

        //OBTEM OS FUNCIONARIOS DE ACORDO COM AS REGRAS DE NEGOCIO
        //CHAMA A FUNÇÃO DE ACESSO DE DADOS, FUNCIONARIODAO-DeletarFUNCIONARIO
        public void DeletarFuncionario(string idFuncionario)
        {
            if((idFuncionario != null)&&(idFuncionario != ""))
            {
                _funcionarioDAO.DeletarFuncionario(idFuncionario);
            }
            this.Teste = "Falha na execucao do metodo";
        }
        
        
    }
}
