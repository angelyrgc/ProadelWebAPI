var MyCors = "MyCors";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyCors,
                      builder =>
                      {
                          builder.WithHeaders("*");
                          builder.WithOrigins("*");
                      });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
