using AgendaApp.API.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Pol�tica de CORS
builder.Services.AddCors(options => 
{
    options.AddPolicy("DefaultPolicy", builder => 
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

//configura��es do AutoMapper
builder.Services.AddAutoMapper(typeof(ProfileMap));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("DefaultPolicy"); //Pol�tica de CORS

app.MapControllers();

app.Run();

//tornando a classe Program p�blica...
public partial class Program { }