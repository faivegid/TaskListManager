using TaskListManager;
using TaskListManager.AppService;
using TaskListManager.AppService.AppTasks;
using TaskListManager.Domain.AppTasks;
using TaskListManager.Domain.DataSource.MockApi;
using TaskListManager.Domain.DataSource.MockApiAppTaskRepositorys;
using TaskListManager.Middleware;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(TaskListManagerMapperProfile));
builder.Services.ConfigureApiBehaviorOptions();

// configure datasource 
builder.Services.AddHttpClient<IMockapiClient, MockapiClient>(httpClient =>
{
    httpClient.BaseAddress = new Uri(config.GetSection("MockApi:BaseUrl").Value);
});
builder.Services.AddScoped<IAppTaskRepository, MockApiAppTaskRepository>();

// configure app service dependency injection
builder.Services.AddScoped<ITaskAppService, TaskAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandleMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
