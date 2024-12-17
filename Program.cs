using MassTransit;
using MTIssue;
using MTIssue.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDefaultBusMassTransit, DefaultBusMassTransit>();
builder.Services.AddScoped<IOtherBusMassTransit, OtherBusMassTransit>();
builder.Services.AddScoped<Service>();

builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "uno", cfgHost => {
            cfgHost.Username("guest");
            cfgHost.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddMassTransit<IOtherBus>(x =>
{
    x.SetKebabCaseEndpointNameFormatter();

    x.AddConsumer<MyConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "dos", cfgHost => {
            cfgHost.Username("guest");
            cfgHost.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});

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
