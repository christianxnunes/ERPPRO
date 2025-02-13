using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPPRO.Persistence.Contexto;
using ERPPRO.Domain;
using Microsoft.AspNetCore.Mvc;
using ERPPRO.Application.Contracts;
using Microsoft.AspNetCore.Http;

namespace ERPPRO.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioApplication _funcionarioApplication;

        public FuncionarioController(IFuncionarioApplication funcionarioApplication)
        {
            _funcionarioApplication = funcionarioApplication;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var funcionarios  = await _funcionarioApplication.GetAllFuncionariosAsync();
                if (funcionarios == null) return NotFound("Nenhum registro encontrado!");
                return Ok(funcionarios);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar todos os funcionários: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> GetId(int id)
        {
            try
            {
                var funcionario = await _funcionarioApplication.GetIdFuncionarioAsync(id);
                if (funcionario == null) return NotFound("Nenhum registro encontrado!");
                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar o funcionário: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Funcionario model)
        {
            try
            {
                var funcionario = await _funcionarioApplication.AddFuncionarios(model);
                if (funcionario == null) return BadRequest("Erro ao tentar adicionar funcionário!");
                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar o funcionário: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Funcionario model)
        {
            try
            {
                var funcionario = await _funcionarioApplication.UpdateFuncionarios(id, model);
                if (funcionario == null) return BadRequest("Erro ao tentar editar funcionário!");
                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar o funcionário: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _funcionarioApplication.DeleteFuncionarios(id)
                    ? Ok("Deletado!")
                    : BadRequest("Funcionário não deletado!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar o funcionário: {ex.Message}");
            }
        }
    }
}