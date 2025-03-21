using Atividade_eventos1.Models;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Host.UseDefaultServiceProvider(options =>

{

    options.ValidateScopes = false; // Ativa a validação de escopo. False evita erro de BD inexistente

});

// Add services to the container.

builder.Services.AddControllersWithViews();

//Configuração da Entity Framework Core

builder.Services.AddDbContext<Context>(options =>

options.UseSqlServer(builder.Configuration["Data:Atividade_eventos1:ConnectionString"],

//evita que o BD não seja criado por problemas de timeout com o servidor

sqlServerOptionsAction: sqlOptions =>

{

    sqlOptions.EnableRetryOnFailure(

    maxRetryCount: 10,

    maxRetryDelay: TimeSpan.FromSeconds(30),

    errorNumbersToAdd: null);

}));

var app = builder.Build();//mantenha o restante do código após esta linha

SeedData.EnsurePopulated(app);