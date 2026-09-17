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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Endpoint /ApplyDatabaseMigrations, по которому работает кнопка "Apply Migrations"
    // на странице ошибки БД (в шаблоне он ошибочно включался только для Production).
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// Проверяем подключение к БД при старте.
// База уже существует (Database First), поэтому миграции не накатываем,
// а просто сообщаем в лог, если подключение не удалось - остальные страницы при этом работают.
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
