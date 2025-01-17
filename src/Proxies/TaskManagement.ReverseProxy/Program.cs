
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "TaskManagement.ReverseProxy", Version = "v1" });
});

builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/usermanagement/swagger.json", "User Management API");
    options.SwaggerEndpoint("/swagger/taskmanagement/swagger.json", "Task Management API");
    options.SwaggerEndpoint("/swagger/projectmanagement/swagger.json", "Project Management API");
});

app.MapReverseProxy();

app.Run();
