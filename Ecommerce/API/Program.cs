var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Funcionalidade - Requisições
// - UrL/Caminho/Endereço
// - Um  Método HTTP

app.MapGet("/", () => "Minha segunda API em C#");

app.MapGet("/endereco", () => "Boa noite");

app.MapPost("/endereco", () => "Funcionalidade do Post");

app.Run();