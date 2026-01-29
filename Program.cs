var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // Importante para o SQL e API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseDefaultFiles(); // Para achar seu index.html
app.UseStaticFiles();  // Para carregar o JavaScript/TypeScript
app.MapControllers();

app.Run();