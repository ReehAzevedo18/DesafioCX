namespace ClientesCX_WebAPI.Models
{
    public class Contatos
    {
        public Contatos()
        {
            
        }
        public Contatos(int id, string nome, string email, string telefone, int idCliente)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.idCliente = idCliente;

        }
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }

        public int idCliente { get; set; }
        public Cliente Cliente { get; set; }

    }
}