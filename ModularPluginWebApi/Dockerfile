var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
 
var app = builder.Build();
 
// ✅ Swagger always enabled (no Development condition)

app.UseSwagger();

app.UseSwaggerUI(c =>

{

    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ModularPluginWebApi v1");

    c.RoutePrefix = string.Empty;   // 👈 THIS makes Swagger load at root "/"

});
 
app.MapControllers();
 
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";

app.Run($"http://0.0.0.0:{port}");
 
