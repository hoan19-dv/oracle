using NLog;
using NLog.Web;
using WebApplication2;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
try
{
    logger.Debug("init main");
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    Connect.addData(1, "hoan", "van", "hanoi", 19, "12a3");
    //Connect.deleteData(1);
    //connect.updateData(1, "duc", "hoang", "hcm", 19, "12a3");
    Connect.getData();
    //object value=cn.Connect();
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
}catch(Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}
