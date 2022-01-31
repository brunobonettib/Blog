using Blog.Data;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
builder.Services.AddDbContext<BlogDataContext>();
builder.Services.AddTransient<TokenService>(); // Sempre cria um novo 


var app = builder.Build();

app.UseAuthentication(); // Autenticação - Quem você é!
app.UseAuthorization();  // Autorização - O que você pode fazer! 

app.MapControllers();

app.Run();