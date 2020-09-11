using NetCoreApi.Models;
using NetCoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly FuncionarioService _funcionarioService;
    
        public FuncionariosController(FuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public ActionResult<List<Funcionario>> Get()
        {
            return _funcionarioService.Get();
        }
        [HttpGet("{id:length(24)}", Name = "GetFuncionario")]
        public ActionResult<Funcionario> Get(string id)
        {
            var funcionario = _funcionarioService.Get(id);

            if(funcionario == null)
            {
                return NotFound();
            }

            return funcionario;
        }

        [HttpPost]
        public ActionResult<Funcionario> Create(Funcionario funcionario)
        {
            _funcionarioService.Create(funcionario);
            return CreatedAtRoute("GetFuncionario", new { id = funcionario.Id.ToString() }, funcionario);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Funcionario func)
        {
            var funcionario = _funcionarioService.Get(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            _funcionarioService.Update(id, func);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var funcionario = _funcionarioService.Get(id);

            if(funcionario == null)
            {
                return NotFound();
            }

            _funcionarioService.Remove(funcionario.Id);

            return NoContent();
        }
    }
}