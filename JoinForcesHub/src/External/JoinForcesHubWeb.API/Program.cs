using JoinForcesHubAPI.Application;
using JoinForcesHubAPI.Infrastructure;
using JoinForcesHubWeb.API.Filters;
using JoinForcesHubWeb.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

//CustomServices
builder.Services
    .AddApplication()
    .AddInfrastructureLayer(builder.Configuration);


builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
