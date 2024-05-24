using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
         private readonly UsuariosRepository _usuarioRepository;

        public UsuariosController(UsuariosRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Usuario usuario = _usuarioRepository.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
        [HttpPost]
        public IActionResult Adicionar(Usuario model)
        {
            _usuarioRepository.Adicionar(model);
            return StatusCode(201);
        }
        
        [HttpPut("{id}")]
        public IActionResult Atualizar ( int id, Usuario model)
        {
            _usuarioRepository.Atualizar(id, model);
            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar( int id )
        {
            try
            {
                _usuarioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }

        }
    }
}