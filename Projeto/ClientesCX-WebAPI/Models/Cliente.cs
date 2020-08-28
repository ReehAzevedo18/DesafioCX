using System.Collections.Generic;

namespace ClientesCX_WebAPI.Models
{
    public class Cliente
    {
        public Cliente()
        {
            
        }

        public Cliente(int id, string nome, string email, string telefone, string dt_registro)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.dt_registro = dt_registro;

        }
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string dt_registro { get; set; }

        public List<Contatos> Contatos { get; set; } 

    }
}