using API.Models;
using Microsoft.AspNetCore.Mvc;
Console.Clear();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Lista de Produtos
List<Produto> produtos = new List<Produto>()
{
    new Produto { Nome = "Mouse Gamer", Quantidade = 50, Preço = 150.75 },
    new Produto { Nome = "Teclado Mecânico RGB", Quantidade = 30, Preço = 450.00 },
    new Produto { Nome = "Monitor 27 Polegadas 144Hz", Quantidade = 20, Preço = 1899.99 },
    new Produto { Nome = "Webcam Full HD", Quantidade = 75, Preço = 215.50 },
    new Produto { Nome = "Headset Gamer com Microfone", Quantidade = 40, Preço = 380.25 },
    new Produto { Nome = "Placa de Vídeo RTX 4070", Quantidade = 15, Preço = 6500.00 },
    new Produto { Nome = "SSD 1TB NVMe", Quantidade = 60, Preço = 550.80 },
    new Produto { Nome = "Notebook Core i7", Quantidade = 10, Preço = 5999.90 },
    new Produto { Nome = "Roteador Wi-Fi 6", Quantidade = 25, Preço = 349.99 },
    new Produto { Nome = "Caixa de Som Bluetooth", Quantidade = 90, Preço = 99.50 }
};

//Funcionalidade - Requisições
// - UrL/Caminho/Endereço
// - Um  Método HTTP

// Métodos HTTP:
// GET    -> Recuperar/Enviar dados do servidor (sem alterar nada)
// POST   -> Enviar novos dados para o servidor (criação)
// PUT    -> Atualizar dados existentes (substituição completa)
// PATCH  -> Atualizar parte dos dados (modificação parcial)
// DELETE -> Remover dados do servidor
// Usados com HttpClient para consumir APIs RESTful.

//GET:/api/produto/listar
app.MapGet("/", () => "API de Produtos  ");

//Get para listar os produtos cadastrados
app.MapGet("/api/produto/listar", () =>
{
    //Validar a lista de produtos para saber se existe algo dentro
    if (produtos.Any())
    {
        return Results.Ok(produtos);
    }
    else
    {
        return Results.NotFound("A lista não possui nenhum produto");
    }

});

//GET: /api/produto/buscar/nome_do_produto
app.MapGet("/api/produto/buscar/{nome}", (string nome) =>
{
    // foreach (Produto produtoCadastrado in produtos)
    // {
    //     if (produtoCadastrado.Nome == nome)
    //         {
    //         return Results.Ok(produtoCadastrado);
    //     }
    // }
    //
    //Expressao Lambda
    Produto? resultado = produtos.FirstOrDefault(x => x.Nome == nome );
    if (resultado is null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    return Results.Ok(resultado);
});


//POST: /api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto) =>
{
    //Não permitir o cadastro de um produto com o mesmo nome

    foreach (Produto produtoCadastrado in produtos)
    {
        if (produtoCadastrado.Nome == produto.Nome)
        {
            return Results.Conflict("Produto já cadastrado");
        }
    }
    produtos.Add(produto);
    return Results.Created("", produto);
});


app.Run();