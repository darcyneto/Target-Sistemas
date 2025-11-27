using TargetSistemas.Services;
using TargetSistemas.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
    });

builder.Services.AddScoped<IJsonDataService, JsonDataService>();

var dataPath = Path.Combine(builder.Environment.ContentRootPath, "Data");
Directory.CreateDirectory(dataPath);

builder.Services.Configure<JsonDataOptions>(options =>
{
    options.VendasPath = Path.Combine(dataPath, "vendas.json");
    options.EstoquePath = Path.Combine(dataPath, "estoque.json");
    options.MovimentacoesPath = Path.Combine(dataPath, "movimentacoes.json");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

try
{
    using var scope = app.Services.CreateScope();
    var jsonService = scope.ServiceProvider.GetRequiredService<IJsonDataService>();
    await jsonService.InitializeAsync();
}
catch (Exception ex)
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Erro ao inicializar arquivos JSON: {Message}", ex.Message);
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

