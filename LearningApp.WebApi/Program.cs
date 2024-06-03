using LearningApp.Application.InfrastructureInterfaces.Persistance;
using LearningApp.Application.Services;
using LearningApp.Infrastructure.Persistance;
using LearningApp.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Add DB Context
builder.Services.AddDbContext<DemoAppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")),
    ServiceLifetime.Scoped);
// Add services to the container.
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductDataService, ProductDataServiceEF>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IAuthDataService, AuthDataService>();
builder.Services.AddTransient<IDocumentService, DocumentService>();
builder.Services.AddTransient<IDocumentDataService, DocumentDataService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
