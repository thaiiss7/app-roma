using AppRoma.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppRomaDbContext>(
    options => options.UseSqlServer(
        Environment.GetEnvironmentVariable("SQL_CONNECTION")
    )
);

var app = builder.Build();

app.Run();
