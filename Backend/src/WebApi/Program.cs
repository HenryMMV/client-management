using Application.Interfaces;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);

// CORS
var originsFromConfig = builder.Configuration.GetSection("Cors:Origins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCors", policy =>
    {
        if (originsFromConfig is { Length: > 0 })
        {
            policy
                .WithOrigins(originsFromConfig)
                .AllowAnyMethod()
                .AllowAnyHeader();
        }
        else
        {
            if (builder.Environment.IsDevelopment())
            {
                policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("DefaultCors");

app.MapGet("/clientes", async (IClienteReadService svc, CancellationToken ct) =>
{
    var data = await svc.GetAllAsync(ct);
    return Results.Ok(data);
})
.WithName("GetClientes")
.Produces<List<object>>(StatusCodes.Status200OK);

app.MapGet("/clientes/{ruc}", async (string ruc, IClienteReadService svc, CancellationToken ct) =>
{
    var item = await svc.GetByRucAsync(ruc, ct);
    return item is not null ? Results.Ok(item) : Results.NotFound();
})
.WithName("GetClienteByRuc")
.Produces<object>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.Run();
