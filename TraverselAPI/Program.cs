using System.Text.Json.Serialization;
using TraverselAPI.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Cors i�lemleri i�in 
builder.Services.AddCors(option =>
{
    option.AddPolicy("TraverselApiCors", opt =>
    {
        opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });

});// Cors i�lemleri i�in 

var app = builder.Build();
//builder.Services.AddDbContext<DatabaseContext>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("TraverselApiCors");// Cors i�lemi i�in
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
