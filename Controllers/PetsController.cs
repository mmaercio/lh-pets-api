using LH_Pets.Data;
using LH_Pets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LH_Pets.Controllers;

[ApiController]
[Route("api/pets")]
public class PetsController(DadosEmMemoria dados) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Pet>> Listar()
    {
        lock (dados.Sincronizacao)
            return Ok(dados.Pets.ToList());
    }

    [HttpPost]
    [ProducesResponseType(typeof(Pet), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Pet> Cadastrar(Pet pet)
    {
        lock (dados.Sincronizacao)
        {
            if (!dados.Clientes.Any(cliente => cliente.Id == pet.ClienteId))
                return BadRequest(new { mensagem = "ClienteId não corresponde a um cliente cadastrado." });

            pet.Id = dados.NovoPetId();
            dados.Pets.Add(pet);
            return Created("/api/pets", pet);
        }
    }

    [HttpGet("cliente/{clienteId:int}")]
    public ActionResult<List<Pet>> ListarPorCliente(int clienteId)
    {
        lock (dados.Sincronizacao)
            return Ok(dados.Pets.Where(pet => pet.ClienteId == clienteId).ToList());
    }
}
