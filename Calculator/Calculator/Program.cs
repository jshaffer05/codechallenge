using Calculator;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
//important it creates one instance of the NumberStore to be used during the entire application
builder.Services.AddSingleton<INumberStore, NumberStore>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
options.WithOrigins("http://localhost:4200")
.AllowAnyMethod()
.AllowAnyHeader());


app.UseAuthorization();

app.MapControllers();

app.Run();
