using NATS.Client;
using System;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var factory = new ConnectionFactory();
var connection = factory.CreateConnection();

app.MapGet("/", () => "Hello World!");

app.MapGet("/publicar", () =>
{
    // Obtener el cuerpo de la solicitud
    // var cuerpo = await request.ReadFromJsonAsync<object>();

    // Convertir el cuerpo en una cadena JSON
    var dto = new { message = "blablabla" };
    var mensaje = JsonSerializer.Serialize(dto);

    // Publicar el mensaje en NATS
    connection.Publish("mi-sujeto", Encoding.UTF8.GetBytes(mensaje));

    // Retornar una respuesta exitosa
    return Results.Ok("Message sended");
});

app.Run();
