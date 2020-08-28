using System.Threading.Tasks;
using ClientesCX_WebAPI.Models;

namespace ClientesCX_WebAPI.Data
{
    public interface IRepository
    {
        //EM COMUM
         void Inserir<T>(T entity) where T : class;
         void Alterar<T>(T entity) where T : class;
         void Excluir<T>(T entity) where T : class;
         bool Salvar();

         Cliente[] GetTodosOsClientes(bool incluirContatos);
         Cliente GetClientePorId(int idCliente, bool incluirContatos);

         Contatos[] GetTodosOsContatos(bool incluirCliente);
         Contatos GetContatosPorId(int idContatos, bool incluirContatos);
    }
}