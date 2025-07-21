using AppRoma.Implementations;
using AppRoma.Models;
using AppRoma.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppRomaDbContext>(
    options => options.UseSqlServer(
        Environment.GetEnvironmentVariable("SQL_CONNECTION")
    )
);


builder.Services.AddTransient<IProfileRepository, EFProfileRepository>();

builder.Services.AddTransient<ILikeRepository, EFLikeRepository>();

var app = builder.Build();

app.Run();
