using CommonFunc;

var builder = WebApplication.CreateBuilder(args);
string directory = Directory.GetCurrentDirectory() + "/appsettings.json";
 var config = new ConfigurationBuilder().AddJsonFile(directory).Build();

CommonFunc.CommonFunction.InitConfigData(config);
// Add services to the container.

builder.Services.AddControllers();
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
