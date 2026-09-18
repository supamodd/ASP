using MyAcademy.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyAcademy.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<MyAcademyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyAcademyContext") ?? throw new InvalidOperationException("Connection string 'MyAcademyContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("MyAcademy");
    try
    {
        var dbFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<MyAcademyContext>>();
        using var db = dbFactory.CreateDbContext();
        if (db.Database.CanConnect())
        {
            logger.LogInformation("Подключение к базе данных '{Database}' установлено.", db.Database.GetDbConnection().Database);
        }
        else
        {
            logger.LogError("База данных недоступна. Проверьте строку подключения 'MyAcademyContext' в appsettings.json.");
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Не удалось подключиться к базе данных. Проверьте строку подключения 'MyAcademyContext' в appsettings.json.");
    }
}

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
