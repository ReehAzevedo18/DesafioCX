using System;
using Microsoft.AspNetCore.Mvc;
using ClientesCX_WebAPI.Data;
using ClientesCX_WebAPI.Models;

namespace ClientesCX_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //definindo a rota da API
    public class ClienteController  : ControllerBase
    {
        //Chamada da interface do repositório
        private readonly IRepository _repo;

        public ClienteController(IRepository repo)
        {
            _repo = repo;
        }

        //Action para buscar todos os clientes da base de dados
        [HttpGet]
        public IActionResult Get(){
             try
            {
                var result = _repo.GetTodosOsClientes(true);
                return Ok(result);

            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        //Action para buscar o cliente por ID
        [HttpGet("ClientePorId/{idCliente}")]
        public IActionResult GetClientePorId(int idCliente, bool incluirContatos){
             try
            {
                var result = _repo.GetClientePorId(idCliente, true);
                return Ok(result);

            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        //Action para gravar os dados do cliente
        [HttpPost]
        public IActionResult post(Cliente cliente){
             try
            {
                _repo.Inserir(cliente);

                if(_repo.Salvar()){
                    return Ok(cliente);
                }

            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        //Action para editar os dados do cliente
        [HttpPut("{idCliente}")]
        public IActionResult put(int idCliente, Cliente cliente){
             try
            {
                var cli = _repo.GetClientePorId(idCliente, false);

                if(cli == null)
                    return NotFound("Cliente não encontrado. Tente novamente!");

                _repo.Alterar(cliente);

                if(_repo.Salvar()){
                    return Ok(cliente);
                }

            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        //Action para buscar excluir o cliente
        [HttpDelete("{idCliente}")]
        public IActionResult delete(int idCliente){
             try
            {
                var cli = _repo.GetClientePorId(idCliente, false);
                if(cli == null)
                    return NotFound("Cliente não encontrado. Tente novamente!");

                _repo.Excluir(cli);

                if(_repo.Salvar()){
                    return Ok(new {message = "Cliente excluído com sucesso!"});
                }

            }catch(Exception ex){
                
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}