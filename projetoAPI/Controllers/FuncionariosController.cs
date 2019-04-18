using System.Collections.Generic;
using projetoAPI.BusinessLayer;
using projetoAPI.DataAccess.Models;
using projetoAPI.DataAccess.DAO;
using projetoAPI.DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;

namespace projetoAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioBll _funcionarioBll;

        //INJEÇÃO DE DEPENDENCIAS
        public FuncionarioController(IFuncionarioBll funcionarioBll)
        {
            _funcionarioBll = funcionarioBll;
        }

        //CONTROLA A OBTENÇÃO DE TODOS OS FUNCIONARIOS CADASTRADOS
        //CHAMA A FUNÇÃO DE VALIDAÇÃO, FUNCIONARIOBLL-ObterTodosFUNCIONARIOs 
        [HttpGet("ObterTodosFuncionarios")]
        public ActionResult<List<Funcionario>> ObterTodosFuncionarios()
        {
            try
            {
                return Ok(_funcionarioBll.ObterTodosFuncionarios());
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        //CONTROLA A OBTENÇÃO DE FUNCIONARIOS CADASTRADOS, POR ID
        //CHAMA A FUNÇÃO DE VALIDAÇÃO, FUNCIONARIOBLL-ObterFUNCIONARIOsPorId
        [HttpGet("ObterFuncionariosPorId/{idFuncionario}")]
        public ActionResult<Funcionario> ObterFuncionariosPorId(string idFuncionario)
        {
            try
            {
                return Ok(_funcionarioBll.ObterFuncionariosPorId(idFuncionario));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        //CONTROLA A OBTENÇÃO DE FUNCIONARIOS CADASTRADOS, POR NOME
        //CHAMA A FUNÇÃO DE VALIDAÇÃO, FUNCIONARIOBLL-ObterFUNCIONARIOsPorNOME
        [HttpGet("ObterFuncionariosPorNome/{nomeFuncionario}")]
        public ActionResult<Funcionario> ObterFuncionariosPorNome(string nomeFuncionario)
        {
            try
            {
                return Ok(_funcionarioBll.ObterFuncionariosPorNome(nomeFuncionario));
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //CONTROLA A ADÇÃO DE FUNCIONARIOS
        //CHAMA A FUNÇÃO DE VALIDAÇÃO, FUNCIONARIOBLL-AdicionarNovoFUNCIONARIO
        [HttpPost("AdcionarNovoFuncionario")]
        public ActionResult<Funcionario> AdcionarNovoFuncionario(FuncionarioDTO funcionario)
        {
            try
            {
                _funcionarioBll.AdcionarNovoFuncionario(funcionario);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //CONTROLA A ATUALIZAÇÃO DE FUNCIONARIOS
        //CHAMA A FUNÇÃO DE VALIDAÇÃO, FUNCIONARIOBLL-AtualizarFUNCIONARIO
        [HttpPut("AtualizarFuncionario/{idFuncionario}")]
        public IActionResult AtualizarFuncionario(string idFuncionario, FuncionarioDTO funcionarioNew)
        {
            try
            {
                _funcionarioBll.AtualizarFuncionario(idFuncionario, funcionarioNew);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //CONTROLA A EXCLUSÃO DE FUNCIONARIOS CADASTRADOS, POR ID
        //CHAMA A FUNÇÃO DE VALIDAÇÃO, FUNCIONARIOBLL-DeletarFUNCIONARIO
        [HttpDelete("DeletarFuncionario/{idFuncionario}")]
        public IActionResult DeletarFuncionario(string idFuncionario)
        {
            try
            {
                _funcionarioBll.DeletarFuncionario(idFuncionario);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
