using WebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer()
                .AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<TodoRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Define a pol�tica de CORS
app.UseCors(c =>
{
    c.AllowAnyOrigin() //Permitir qualquer origem.
     .AllowAnyHeader() //Permitir qualquer header.
     .AllowAnyMethod(); //Permitir qualquer m�todo.
});

app.UseAuthorization();

app.MapControllers();

app.Run();
