using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClientesCX_WebAPI.Models;

namespace ClientesCX_WebAPI.Data
{
    public class Repository : IRepository
    {
        //variavel para chamar o dataContext
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
    
    #region Métodos genéricos para clientes e contatos
       public void Inserir<T>(T entity) where T : class
        {
             _context.Add(entity);
        }

        public void Alterar<T>(T entity) where T : class
        {
             _context.Update(entity);
        }

        public void Excluir<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }
    #endregion

        public Cliente GetClientePorId(int idCliente, bool incluirContatos)
        {
            IQueryable<Cliente> query = _context.Cliente;

           if(incluirContatos){
               query = query.Include(co => co.Contatos);
           }

           query = query.AsNoTracking()
                        .OrderBy(cli => cli.id)
                        .Where(cli => cli.id == idCliente);

            return query.FirstOrDefault();
        }

        public Contatos GetContatosPorId(int idContatos, bool incluirContatos)
        {
            IQueryable<Contatos> query = _context.Contatos;

            if(incluirContatos){
                query = query.Include(co => co.Cliente);
            }

            query = query.AsNoTracking()
                        .OrderBy(a => a.id)
                        .Where(cont => cont.id == idContatos);

            return query.FirstOrDefault();
        }

        public Cliente[] GetTodosOsClientes(bool incluirContatos)
        {
             IQueryable<Cliente> query = _context.Cliente;

           if(incluirContatos){
               query = query.Include(co => co.Contatos);
           }

           query = query.AsNoTracking().OrderBy(a => a.id);

           return query.ToArray();
        }

        public Contatos[] GetTodosOsContatos(bool incluirCliente)
        {
              IQueryable<Contatos> query = _context.Contatos;

             if(incluirCliente){
                 query = query.Include(cli => cli.Cliente);
             }

             query = query.AsNoTracking().OrderBy(co => co.id);

             return query.ToArray();
        }

       public bool Salvar()
        {
           return (_context.SaveChanges() > 0);
        }
    }
}