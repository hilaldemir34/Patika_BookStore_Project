using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookStore.DbOperations; // Explicitly use this namespace for BookStoreDbContext
using BookStore;

var builder = WebApplication.CreateBuilder(args);

// DbContext servisini DI container'a ekliyoruz
builder.Services.AddDbContext<BookStore.DbOperations.BookStoreDbContext>(options =>
    options.UseInMemoryDatabase("BookStoreDB"));

// Diğer servis kayıtları (örneğin: controllers, swagger vs.)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 📌 Örnek verileri seed ediyoruz
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services); // Sample veri üretici metodun
}

// Swagger kullanımı (isteğe bağlı)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();