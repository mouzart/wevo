using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste.Data;
using teste.Models;

namespace teste.Business
{
    public class UsuarioBO
    {
        private readonly ApplicationDbContext _context;

        public UsuarioBO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Find(int id)
        {
            try
            {
                return await _context.Usuarios.FindAsync(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<List<Usuario>> List()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> Insert(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return await Find(usuario.Id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            try
            {
                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return await Find(usuario.Id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var usuario = await Find(id);
                if (usuario == null)
                {
                    return false;
                }
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
                throw;
            }
        }

    }
}