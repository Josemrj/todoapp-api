var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer()
                .AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Define a política de CORS
app.UseCors(c =>
{
    c.AllowAnyOrigin() //Permitir qualquer origem.
     .AllowAnyHeader() //Permitir qualquer header.
     .AllowAnyMethod(); //Permitir qualquer método.
});

app.UseAuthorization();

app.MapControllers();

app.Run();
