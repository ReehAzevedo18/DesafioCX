using System.Collections.Generic;
using ClientesCX_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesCX_WebAPI.Data
{
    public class DataContext : DbContext
    {
        //Setando as Models
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Cliente> Cliente {get;set;}
        public DbSet<Contatos> Contatos {get;set;}

        //Inserindo no banco
        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Cliente>()
                .HasData(new List<Cliente>(){
                    new Cliente(1, "Renata", "renata@cx.com.br", "242424",  "22/08/2020"),
                    new Cliente(2, "Roger", "rtavares@cx.com.br", "203030",  "12/08/2020"),
                    new Cliente(3, "Ricardo", "lima@cx.com.br", "949493",  "22/08/2020"),
                    new Cliente(4, "Rayssa", "rdiego@cx.com.br", "202010",  "21/08/2020")
                });

            builder.Entity<Contatos>()
                .HasData(new List<Contatos>(){
                    new Contatos(1, "Paula", "renata@cx.com.br", "242424", 1),
                    new Contatos(2, "Laura", "rtavares@cx.com.br", "203030", 1),
                    new Contatos(3, "Lima", "lima@cx.com.br", "949493",3),
                    new Contatos(4, "Teste", "teste@cx.com.br", "050504",4)
                });

        }
    }
}