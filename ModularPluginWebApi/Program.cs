using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var pluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");

if (Directory.Exists(pluginPath))
{
    foreach (var file in Directory.GetFiles(pluginPath, "*.dll"))
    {
        var assembly = Assembly.LoadFrom(file);
        builder.Services.AddControllers()
            .PartManager.ApplicationParts.Add(new AssemblyPart(assembly));
    }
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
