using System;
using Microsoft.AspNetCore.Mvc;
using ClientesCX_WebAPI.Data;
using ClientesCX_WebAPI.Models;


namespace ClientesCX_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //rota para a API
    public class ContatosController : ControllerBase
    {

        private readonly IRepository _repo;
        
        //Construtor para receber a interface do repositório
        public ContatosController(IRepository repo){
            _repo = repo;
        }

      //Action para buscar todos os contatos da base de dados
        [HttpGet]
        public IActionResult Get(){
             try
            {
                var result = _repo.GetTodosOsContatos(true);
                return Ok(result);

            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        //Action para buscar o contato por ID
        [HttpGet("ContatosPorId/{idContatos}")]
        public IActionResult GetContatosPorId(int idContatos, bool incluirContatos){
             try
            {
                var result = _repo.GetContatosPorId(idContatos, true);
                return Ok(result);

            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        //Action para gravar o contato
        [HttpPost]
        public IActionResult post(Contatos contatos){
             try
            {
                _repo.Inserir(contatos);

                if(_repo.Salvar()){
                    return Ok(contatos);
                }

            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        //Action para editar o contato recebendo como paramento na URL o ID
        [HttpPut("{idContatos}")]
        public IActionResult put(int idContatos, Contatos contatos){
             try
            {
                var cont = _repo.GetContatosPorId(idContatos, false);

                if(cont == null)
                    return NotFound("Contato não encontrado. Tente novamente!");

                _repo.Alterar(contatos);

                if(_repo.Salvar()){
                    return Ok(contatos);
                }

            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        //Action para excluir o contato recebendo como paramento na URL o ID
        [HttpDelete("{idContatos}")]
        public IActionResult delete(int idContatos){
             try
            {
                var cli = _repo.GetContatosPorId(idContatos, false);
                if(cli == null)
                    return NotFound("Contato não encontrado. Tente novamente!");

                _repo.Excluir(cli);

                if(_repo.Salvar()){
                    return Ok(new {message = "Contato excluído com sucesso!"});
                }

            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

    }
}