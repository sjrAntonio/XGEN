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
    public class tbEnderecoController : ControllerBase
    {
        private readonly IRepository _repository;

        public tbEnderecoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<tb_endereco>>> tb_enderecoList()
        {
            return await _repository.SelectAll<tb_endereco>();
        }

        [HttpGet("{ID_CLIENTE}")]
        public async Task<ActionResult<tb_endereco>> Gettb_endereco(long ID_CLIENTE)
        {
            var model = await _repository.SelectByIdCiente<tb_endereco>(ID_CLIENTE);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        [HttpPut("{ID_ENDERECO}")]
        public async Task<IActionResult> Updatetb_endereco(long ID_ENDERECO, tb_endereco model)
        {
            if (ID_ENDERECO != model.ID_ENDERECO)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync<tb_endereco>(model);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<tb_endereco>> Inserttb_endereco([FromBody] tb_endereco model)
        {
            await _repository.CreateAsync<tb_endereco>(model);
            return CreatedAtAction("Gettb_endereco", new { id = model.ID_ENDERECO }, model);
        }

        [HttpDelete("{ID_ENDERECO}")]
        public async Task<ActionResult<tb_endereco>> Deletetb_endereco(long ID_ENDERECO)
        {
            var model = await _repository.SelectByIdEndereco<tb_endereco>(ID_ENDERECO);

            if (model == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync<tb_endereco>(model);

            return model;
        }
    }
}
