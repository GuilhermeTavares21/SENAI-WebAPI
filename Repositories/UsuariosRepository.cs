using Exo.WebApi.Contexts;
using Exo.WebApi.Models;

namespace Exo.WebApi.Repositories
{
    public class UsuariosRepository
    {
        private readonly ExoContext _context;

        public UsuariosRepository(ExoContext context)
        {
            _context = context;
        }

        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetById(int UsuarioId)
        {
            return _context.Usuarios.FirstOrDefault(item => item.Id == UsuarioId);
        }
        public void Adicionar(Usuario model)
        {
            _context.Usuarios.Add(model);
            _context.SaveChanges();
        }
        public void Atualizar(int id, Usuario model)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            if(usuario != null)
            {
                usuario.Email = model.Email;
                usuario.Senha = model.Senha;
            }
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }
        public void Deletar (int id)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }
    }
}