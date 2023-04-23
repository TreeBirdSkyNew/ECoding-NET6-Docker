using __WEB_API__TemplateResult_WebApi;
using _4___E_CODING_DAL;
using AutoMapper;
using E_CODING_Service_Abstraction;
using E_CODING_Service_Abstraction.Result;
using E_CODING_Services;
using E_CODING_Services.Result;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<TemplateProjectDbContext>(
                    item => item.UseSqlServer("Server=SQLEXPRESS; Database=ECODING; Integrated Security=SSPI; "));

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<ITemplateResultRepository, TemplateResultRepository>();
builder.Services.AddScoped<IResultRepositoryWrapper, ResultRepositoryWrapper>();


var app = builder.Build();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();