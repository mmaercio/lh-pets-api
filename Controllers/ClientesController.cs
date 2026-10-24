using LH_Pets.Data;
using LH_Pets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LH_Pets.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClientesController(DadosEmMemoria dados) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Cliente>> Listar()
    {
        lock (dados.Sincronizacao)
            return Ok(dados.Clientes.ToList());
    }

    [HttpPost]
    [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Cliente> Cadastrar(Cliente cliente)
    {
        lock (dados.Sincronizacao)
        {
            cliente.Id = dados.NovoClienteId();
            dados.Clientes.Add(cliente);
            return Created("/api/clientes", cliente);
        }
    }
}
