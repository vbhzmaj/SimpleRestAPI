using CommandsREST.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CommanderContext>(opt => {opt.UseSqlServer(builder.Configuration.GetConnectionString("CommanderConnection"));});

builder.Services.AddControllers().AddNewtonsoftJson(s => {s.SerializerSettings.ContractResolver =
                                                          new CamelCasePropertyNamesContractResolver();});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICommandsRepo, SQLCommandsRepo>();
//builder.Services.AddTransient<ICommandsRepo, MockCommandsRepo>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
