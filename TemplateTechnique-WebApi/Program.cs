using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_Service_Abstraction;
using E_CODING_Service_Abstraction.Project;
using E_CODING_Service_Abstraction.Technique;
using E_CODING_Services;
using E_CODING_Services.Project;
using E_CODING_Services.Technique;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;
using TemplateProject_WebApi.Extensions;
using TemplateTechnique_WebApi;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureSqlServerContext();

builder.Services.AddScoped<ITemplateTechniqueRepository, TemplateTechniqueRepository>();
builder.Services.AddScoped<ITechniqueRepositoryWrapper, TechniqueRepositoryWrapper>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
