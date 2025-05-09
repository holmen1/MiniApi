using Microsoft.EntityFrameworkCore;
using MiniApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/data", async (SampleDataDto dataDto, AppDbContext dbContext) =>
    {
        // Map DTOs to domain models
        var users = dataDto.Users.Select(dto => new User
        {
            FirstName = dto.First,
            LastName = dto.Last,
            Age = dto.Age
        }).ToList();

        var orders = dataDto.Orders.Select(dto => new Order
        {
            Region = Enum.Parse<Region>(dto.Region, true),
            Portfolio = Enum.Parse<Portfolio>(dto.Portfolio, true),
            Value = dto.Value
        }).ToList();
        
        dbContext.Users.AddRange(users);
        dbContext.Orders.AddRange(orders);
        await dbContext.SaveChangesAsync();

        // Process the domain models (e.g., save to a database)
        return Results.Ok(new { Users = users, Orders = orders });
    })
    .WithName("PostSampleData")
    .WithOpenApi();

app.Run();

