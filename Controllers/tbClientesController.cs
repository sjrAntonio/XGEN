using Angular_Teste.Models;
using Angular_Teste.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tb_clienteController : ControllerBase
    {
        private readonly IRepository _repository;

        public tb_clienteController(IRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tb_cliente>>> tb_clienteList()
        {
            return await _repository.SelectAll<tb_cliente>();
        }

        [HttpGet("{ID_CLIENTE}")]
        public async Task<ActionResult<tb_cliente>> Gettb_cliente(long ID_CLIENTE)
        {
            var model = await _repository.SelectByIdCiente<tb_cliente>(ID_CLIENTE);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        [HttpPut("{ID_CLIENTE}")]
        public async Task<IActionResult> Updatetb_cliente(long ID_CLIENTE, tb_cliente model)
        {
            if (ID_CLIENTE != model.ID_CLIENTE)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync<tb_cliente>(model);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<tb_cliente>> Inserttb_cliente([FromBody] tb_cliente model)
        {
            await _repository.CreateAsync<tb_cliente>(model);
            return CreatedAtAction("Gettb_cliente", new { id = model.ID_CLIENTE }, model);
        }

        [HttpDelete("{ID_CLIENTE}")]
        public async Task<ActionResult<tb_cliente>> Deletetb_cliente(long ID_CLIENTE)
        {
            var model = await _repository.SelectByIdCiente<tb_cliente>(ID_CLIENTE);

            if (model == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync<tb_cliente>(model);

            return model;
        }
    }
}
