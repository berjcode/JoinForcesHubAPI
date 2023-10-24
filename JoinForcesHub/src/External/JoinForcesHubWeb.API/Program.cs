using JoinForcesHubAPI.Application;
using JoinForcesHubAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//CustomServices
builder.Services
    .AddApplication()
    .AddInfrastructureLayer(builder.Configuration);


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
