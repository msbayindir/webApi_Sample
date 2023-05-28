using NLog;
using Repositories.Contracts;
using Repositories.EfCore;
using Services.Contract;
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
builder.Services.AddAutoMapper(typeof(Program));




var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsProduction())
{
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

