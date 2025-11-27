using Microsoft.AspNetCore.Mvc;
using TargetSistemas.Models;
using TargetSistemas.Services;

namespace TargetSistemas.Controllers;

public class ComissaoController : Controller
{
    private readonly IJsonDataService _jsonDataService;

    public ComissaoController(IJsonDataService jsonDataService)
    {
        _jsonDataService = jsonDataService;
    }

    public async Task<IActionResult> Index()
    {
        var vendasData = await _jsonDataService.GetVendasAsync();
        var resultados = ComissaoService.CalcularComissoesPorVendedor(vendasData.Vendas);

        return View(resultados);
    }
}

