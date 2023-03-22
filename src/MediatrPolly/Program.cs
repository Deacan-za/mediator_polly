using MediatrPolly.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.ConfigureStartUp();
builder.Services.ConfigureExchangeRateService(builder.Configuration);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(options =>
  {
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
  });
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.UseRouting();
app.MapHealthChecks("/healthz");


app.MapControllers();

app.Run();
