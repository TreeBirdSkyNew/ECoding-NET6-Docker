using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_Service_Abstraction;
using E_CODING_Service_Abstraction.Project;
using E_CODING_Services;
using E_CODING_Services.Project;
using Microsoft.EntityFrameworkCore;
using TemplateProject_WebApi;
using NLog;
using TemplateProject_WebApi.Extensions;
using Microsoft.Extensions.Options;
using FluentAssertions.Common;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.HttpOverrides;
using System;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureSqlServerContext();

builder.Services.AddScoped<ITemplateProjectRepository, TemplateProjectRepository>();
builder.Services.AddScoped<IProjectRepositoryWrapper, ProjectRepositoryWrapper>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AccountOwner API",
        Version = "v1"
    });
});


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();

var app = builder.Build();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AccountOwner API V1");
});

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



