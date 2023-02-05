using System.Text.Json.Serialization;
using TraverselAPI.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Cors iþlemleri için 
builder.Services.AddCors(option =>
{
    option.AddPolicy("TraverselApiCors", opt =>
    {
        opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });

});// Cors iþlemleri için 

var app = builder.Build();
//builder.Services.AddDbContext<DatabaseContext>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("TraverselApiCors");// Cors iþlemi için
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
