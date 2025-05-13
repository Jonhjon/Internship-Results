using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using NSwag.AspNetCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI; // 新增這行來引入 Swashbuckle.AspNetCore.SwaggerUI 命名空間

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerDocument();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{

}

app.UseOpenApi();
//app.UseSwaggerUi3(); // 啟動 Swagger UI，修正方法名稱
app.UseSwaggerUI(c => // 新增這行來啟動 Swashbuckle 的 Swagger UI
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
