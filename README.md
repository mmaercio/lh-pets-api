# LH-Pets — Web API

Projeto da atividade de Codificação para BackEnd do SENAI. API em C# com ASP.NET Core 8, Controllers, Swagger e armazenamento em memória com `List<T>`.

## Executar

Requisito: .NET SDK 8 instalado.

Na pasta do projeto, execute:

```sh
dotnet restore
dotnet run --launch-profile http
```

Abra http://localhost:5024/swagger para testar. Os dados começam vazios e são perdidos ao encerrar a aplicação. Não é necessário banco de dados.

## Endpoints

| Método | Rota | Resultado |
| --- | --- | --- |
| GET | `/api/clientes` | Lista todos os clientes |
| POST | `/api/clientes` | Cadastra cliente |
| GET | `/api/pets` | Lista todos os pets |
| POST | `/api/pets` | Cadastra pet de um cliente existente |
| GET | `/api/pets/cliente/{clienteId}` | Lista pets do cliente informado |

## Roteiro de teste no Swagger

1. Execute GET `/api/clientes`: retorna 200 e `[]` inicialmente.
2. Expanda POST `/api/clientes`, clique em **Try it out**, use o JSON abaixo e clique em **Execute**:

```json
{
  "nome": "Ana Silva",
  "cpf": "12345678901",
  "email": "ana@example.com"
}
```

Retorno esperado: 201 e cliente com `id: 1`. O ID é gerado pela API; qualquer ID enviado é substituído.

3. Execute novamente GET `/api/clientes` e confira o cliente.
4. Cadastre um pet em POST `/api/pets`:

```json
{
  "nome": "Rex",
  "especie": "Cachorro",
  "raca": "SRD",
  "clienteId": 1
}
```

Retorno esperado: 201 e pet com `id: 1`.

5. Execute GET `/api/pets` e GET `/api/pets/cliente/1`: ambos devem retornar Rex.
6. Cadastre outro cliente e outro pet com `clienteId: 2`. Confira que o filtro do cliente 1 continua retornando apenas Rex.
7. Tente cadastrar um pet com `clienteId: 999`: deve retornar 400.
8. Tente cadastrar cliente sem nome ou com email inválido: deve retornar 400.
9. Consulte um cliente sem pets: o filtro retorna 200 e `[]`.

O CPF é validado pelo formato (11 dígitos com ou sem pontuação), sem cálculo dos dígitos verificadores. Use apenas dados fictícios nos testes.

## Organização

- `Models/`: classes Cliente e Pet com atributos de validação.
- `Controllers/`: rotas HTTP e respostas da API.
- `Data/DadosEmMemoria.cs`: listas compartilhadas, geração de IDs e sincronização.
- `Program.cs`: registro dos serviços e configuração do Swagger.

`[ApiController]` executa as validações dos modelos e responde 400 para dados inválidos. O serviço singleton mantém as listas entre requisições. O vínculo entre pet e cliente usa `ClienteId`.

## Entrega

Publique esta pasta em um repositório **público** no GitHub. Confira se o README e os arquivos `.cs` aparecem no repositório e envie o link dele na caixa de texto do AVA.
