using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository _projetoRepository;

        public ProjetosController(ProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_projetoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Projeto projeto = _projetoRepository.GetById(id);
            if (projeto == null)
            {
                return NotFound();
            }
            return Ok(projeto);
        }
        [HttpPost]
        public IActionResult Adicionar(Projeto model)
        {
            _projetoRepository.Adicionar(model);
            return StatusCode(201);
        }
        
        [HttpPut("{id}")]
        public IActionResult Atualizar ( int id, Projeto model)
        {
            _projetoRepository.Atualizar(id, model);
            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar( int id )
        {
            try
            {
                _projetoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }

        }


    }
}