using Exo.WebApi.Contexts;
using Exo.WebApi.Models;

namespace Exo.WebApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoContext _context;

        public ProjetoRepository(ExoContext context)
        {
            _context = context;
        }

        public List<Projeto> Listar()
        {
            return _context.Projetos.ToList();
        }

        public Projeto GetById(int ProjetoId)
        {
            return _context.Projetos.FirstOrDefault(item => item.Id == ProjetoId);
        }
        public void Adicionar(Projeto model)
        {
            _context.Projetos.Add(model);
            _context.SaveChanges();
        }
        public void Atualizar(int id, Projeto model)
        {
            Projeto projeto = _context.Projetos.Find(id);
            if(projeto != null)
            {
                projeto.Nome = model.Nome;
                projeto.Area = model.Area;
                projeto.Status = model.Status;
            }
            _context.Projetos.Update(projeto);
            _context.SaveChanges();
        }
        public void Deletar (int id)
        {
            Projeto projeto = _context.Projetos.Find(id);
            _context.Projetos.Remove(projeto);
            _context.SaveChanges();
        }
    }
}