using Microsoft.EntityFrameworkCore;
using TransactionService.Business.Implementation;
using TransactionService.Business.Interface;
using TransactionService.Data;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Configuration["LocalEnviroment"] == "true")
{
	builder.Services.AddDbContext<TransactionDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection")));
}
else
{
	builder.Services.AddDbContext<TransactionDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

builder.Services.AddHttpClient<ITransactionsService, TransactionsService>();
builder.Services.AddScoped<ITransactionsService, TransactionsService>();

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
