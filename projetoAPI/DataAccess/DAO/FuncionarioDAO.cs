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

namespace projetoAPI.DataAccess.DAO
{
    public class FuncionarioDAO : IFuncionarioDAO
    {
        //VERIFICAÇÃO DE TESTES UNITARIOS
        public string Teste = "teste";
        private readonly IMongoContext _context;

        //INJEÇÃO DE DEPENDECIAS
        public FuncionarioDAO(IMongoContext context)
        {
            _context = context;
        }

        //ObTEM TODOS OS FUNCIONARIOS QUE ESTEJAM SALVOS NO BANCO
        public List<FuncionarioDTO> ObterTodosFuncionarios()
        {
            List<FuncionarioDTO> funcionarios = new List<FuncionarioDTO>();

            var Funcionarios = _context.CollectionFuncionario.Find(funcionario => true).ToList() ;

           foreach (var item in Funcionarios)
            {
                FuncionarioDTO c = new FuncionarioDTO{
                    IdFuncionario = item.IdFuncionario,
                    NomeFuncionario = item.NomeFuncionario,
                    IdadeFuncionario = item.IdadeFuncionario,
                    FuncaoFuncionario = item.FuncaoFuncionario,
                };

                funcionarios.Add(c);
            }
            
            return funcionarios;
        }

        //OBTEM O FUNCIONARIO SALVO NO BANCO QUE TENHA O ID INFORMADO
        public FuncionarioDTO ObterFuncionariosPorId(string idFuncionario)
        {
            if(idFuncionario != null)
            {
                var resultado = _context.CollectionFuncionario.Find<Funcionario>(funcionario => funcionario.IdFuncionario == idFuncionario).FirstOrDefault();

                FuncionarioDTO funcionarioDTO = new FuncionarioDTO{
                    IdFuncionario = resultado.IdFuncionario,
                    NomeFuncionario = resultado.NomeFuncionario,
                    IdadeFuncionario = resultado.IdadeFuncionario,
                    FuncaoFuncionario = resultado.FuncaoFuncionario,
                };

                return funcionarioDTO;
            }
            this.Teste = "Falha ao executar o metodo";
            return null;
        }

        //OBTEM OS FUNCIONARIOS SALVOS NO BANCO QUE TENHAM O NOME INFORMADO
        public FuncionarioDTO ObterFuncionariosPorNome(string nomeFuncionario)
        {
            if(nomeFuncionario != null)
            {
                var resultado = _context.CollectionFuncionario.Find<Funcionario>(funcionario => funcionario.NomeFuncionario == nomeFuncionario ).FirstOrDefault();

                FuncionarioDTO funcionarioDTO = new FuncionarioDTO{
                    IdFuncionario = resultado.IdFuncionario,
                    NomeFuncionario = resultado.NomeFuncionario,
                    IdadeFuncionario = resultado.IdadeFuncionario,
                    FuncaoFuncionario = resultado.FuncaoFuncionario
                };

                return funcionarioDTO;
            }
            this.Teste = "Falha ao executar o metodo";
            return null;
        }

        //ADICIONA UM NOVO FUNCIONARIO AO BANCO DE DADOS
        //(APENAS O NOME DEVE SER INFORMADA)
        public void AdcionarNovoFuncionario(FuncionarioDTO funcionario)
        {
            if(funcionario != null)
            {
                Funcionario funcionarioNovo = new Funcionario{
                    NomeFuncionario = funcionario.NomeFuncionario,
                    IdadeFuncionario = funcionario.IdadeFuncionario,
                    FuncaoFuncionario = funcionario.FuncaoFuncionario
                };
            
                _context.CollectionFuncionario.InsertOne(funcionarioNovo);
            }
            this.Teste = "Falha ao executar o metodo";
        }

        //ATUALIZA OS DADOS DE UM FUNCIONARIO SALVO, ATRAVEZ DE SEU ID
        public void AtualizarFuncionario(string idFuncionario, FuncionarioDTO funcionarioNew)
        {
            if((idFuncionario != null)&&(funcionarioNew != null))
            {
                Funcionario funcionarioNovo = new Funcionario{
                    IdFuncionario = idFuncionario,
                    NomeFuncionario = funcionarioNew.NomeFuncionario,
                    IdadeFuncionario = funcionarioNew.IdadeFuncionario,
                    FuncaoFuncionario = funcionarioNew.FuncaoFuncionario
                };

                _context.CollectionFuncionario.ReplaceOne(funcionario => funcionario.IdFuncionario == idFuncionario, funcionarioNovo);
            }
            this.Teste = "Falha ao executar o metodo";
        }

        //DELETA UM FUNCIONARIO DO BANCO, ATRAVEZ DO SEU ID
        public void DeletarFuncionario(string idFuncionario)
        {
            if(idFuncionario != null)
            {
                _context.CollectionFuncionario.DeleteOne(funcionario => funcionario.IdFuncionario == idFuncionario);
            }
            this.Teste = "Falha ao executar o metodo";
        }

    }
}
