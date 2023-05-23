using NLog;
using Repositories.Contracts;
using Repositories.EfCore;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(),"/nLog.config"));
builder.Services
    .AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReferance).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigurSqlContext(builder.Configuration);
builder.Services.AddSwaggerGen();

builder.Services.ConfigurRepositoryManager();
builder.Services.ConfigurProductRepository();
builder.Services.ConfigurServiceManager();
builder.Services.ConfigurProductService();
builder.Services.ConfigurLoggerService();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

