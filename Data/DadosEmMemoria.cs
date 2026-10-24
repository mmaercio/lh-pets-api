using LH_Pets.Models;

namespace LH_Pets.Data;

public class DadosEmMemoria
{
    public List<Cliente> Clientes { get; } = new();
    public List<Pet> Pets { get; } = new();
    public object Sincronizacao { get; } = new();
    private int proximoClienteId = 1;
    private int proximoPetId = 1;

    public int NovoClienteId() => proximoClienteId++;
    public int NovoPetId() => proximoPetId++;
}
