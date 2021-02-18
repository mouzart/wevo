using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teste.Business;
using teste.Data;
using teste.Models;

namespace teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private UsuarioBO usuarioBO;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
            usuarioBO = new UsuarioBO(context);
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<List<Usuario>> GetUsuarios()
        {
            return await usuarioBO.List();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await usuarioBO.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }


            return await usuarioBO.Update(usuario);
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            return await usuarioBO.Insert(usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUsuario(int id)
        {
            return await usuarioBO.Delete(id);
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
