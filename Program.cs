using GridironInsuranceAPI.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(s =>
{
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseInMemoryDatabase("GridironInsuranceAPI");
});
// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
//add CORS
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
