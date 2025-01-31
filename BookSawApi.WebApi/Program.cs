using BookSawApi.BusinessLayer.Abstract;
using BookSawApi.BusinessLayer.Concrete;
using BookSawApi.DataAccessLayer.Abstract;
using BookSawApi.DataAccessLayer.Context;
using BookSawApi.DataAccessLayer.EntityFramework;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal,EfCategoryDal>();


builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal,EfProductDal>();


builder.Services.AddScoped<IAuthorService, AuthorManager>();
builder.Services.AddScoped<IAuthorDal,EfAuthorDal>();
builder.Services.AddDbContext<BookSawContext>();

builder.Services.AddScoped<IArticleService, ArticleManager>();
builder.Services.AddScoped<IArticleDal,EfArticleDal>();

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
