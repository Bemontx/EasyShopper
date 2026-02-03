using EasyShopper.Application.DependencyInjection;
using EasyShopper.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Application (CQRS, MediatR, Validators)
builder.Services.AddApplication();

// Infrastructure (EF, Identity, Repos, DbContext)
builder.Services.AddInfrastructure(builder.Configuration);

// API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
