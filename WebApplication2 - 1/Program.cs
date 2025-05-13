
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerDocument(); // �s�W�o��ӵ��U Swagger �A��
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

}

app.UseOpenApi(); // �Ұ� OpenAPI ���
app.UseSwaggerUI(); // �Ұ� Swagger UI
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

