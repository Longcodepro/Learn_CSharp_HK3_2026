using UsersApp.Api.Repositories;
using UsersApp.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<UsersService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Users API v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
