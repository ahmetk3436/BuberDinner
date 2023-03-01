using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
 
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation() 
    ;
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
        app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

}

