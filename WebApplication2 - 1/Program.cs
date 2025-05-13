
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerDocument(); // 新增這行來註冊 Swagger 服務
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

}

app.UseOpenApi(); // 啟動 OpenAPI 文件
app.UseSwaggerUI(); // 啟動 Swagger UI
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

