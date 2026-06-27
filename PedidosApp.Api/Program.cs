using MediatR;
using Microsoft.EntityFrameworkCore;
using PedidosApp.Api.Contexts;
using PedidosApp.Api.Handlers;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<SqlServerContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SQLSERVER")
    )
);

builder.Services.AddScoped<MongoDbContext>();
builder.Services.AddScoped<PedidoNotificationHandler>();

builder.Services.AddMediatR(m => {
    m.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});

builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.MapScalarApiReference(s => s.WithTheme(ScalarTheme.DeepSpace));

app.UseAuthorization();

app.MapControllers();

app.Run();
