using AspNetCoreRateLimit;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using NLog;
using Services.Contract;
using WebApi.Extensions;
using WebApi.Utilities.Formatters;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(),"/nLog.config"));

builder.Services
    .AddControllers(conf =>
    {
        conf.RespectBrowserAcceptHeader = true;
        conf.ReturnHttpNotAcceptable = true;
    })
    .AddCustomCsvFormatter()
    .AddCacheProfile()
    .AddApplicationPart(typeof(Presentation.AssemblyReferance).Assembly)
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<ApiBehaviorOptions>(opt => {
    
    opt.SuppressModelStateInvalidFilter = true;
});

builder.Services.ConfigureActionFilter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigurSqlContext(builder.Configuration);
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1",new OpenApiInfo()
    {
        Version = "v1.0",
        Title = "Sefa",
        Description = "Açıklama Alanı"
    });
    opt.SwaggerDoc("v2",new OpenApiInfo()
    {
        Version = "v2.0",
        Title = "Sefa",
        Description = "Açıklama Alanı"
    });
});

builder.Services.ConfigurRepositoryManager();
builder.Services.ConfigurProductRepository();
builder.Services.ConfigurServiceManager();
builder.Services.ConfigurProductService();
builder.Services.ConfigurLoggerService();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureDataShapper();
builder.Services.ConfigureVersioning();
builder.Services.AddResponseCaching();
builder.Services.AddHttpCacheHeaders(opt =>
{
    opt.CacheLocation = CacheLocation.Public;
    opt.MaxAge = 70;
});

builder.Services.AddMemoryCache();
builder.Services.ConfigureRateLimit(builder.Configuration);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json","deneme1");
        opt.SwaggerEndpoint("/swagger/v2/swagger.json","deneme2");
    });
}
if (app.Environment.IsProduction())
{
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseIpRateLimiting();
app.UseResponseCaching();
app.UseHttpCacheHeaders();
app.UseAuthorization();

app.MapControllers();

app.Run();

