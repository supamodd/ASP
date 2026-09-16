using Movies.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movies.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<MoviesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesContext") ?? throw new InvalidOperationException("Connection string 'MoviesContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Эндпоинт /ApplyDatabaseMigrations, по которому стучит кнопка "Apply Migrations"
    // на странице ошибки БД. В шаблоне он был ошибочно включён только для Production,
    // из-за чего в Development кнопка отдавала 404.
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

// Создаём БД (если её ещё нет) и накатываем все неприменённые миграции при старте.
// Ошибка только логируется, чтобы остальные страницы сайта продолжали работать.
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<MoviesContext>>();
        using var db = dbFactory.CreateDbContext();
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("Migrations");
        logger.LogError(ex, "Не удалось создать базу данных или применить миграции. " +
                            "Проверьте строку подключения и выполните: dotnet ef database update");
    }
}

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
