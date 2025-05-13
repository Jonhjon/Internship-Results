using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using NSwag.AspNetCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI; // �s�W�o��ӤޤJ Swashbuckle.AspNetCore.SwaggerUI �R�W�Ŷ�

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
//app.UseSwaggerUi3(); // �Ұ� Swagger UI�A�ץ���k�W��
app.UseSwaggerUI(c => // �s�W�o��ӱҰ� Swashbuckle �� Swagger UI
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
