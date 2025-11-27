using Microsoft.AspNetCore.Mvc;
using TargetSistemas.Services;

namespace TargetSistemas.Controllers;

public class EstoqueController : Controller
{
    private readonly IJsonDataService _jsonDataService;

    public EstoqueController(IJsonDataService jsonDataService)
    {
        _jsonDataService = jsonDataService;
    }

    public async Task<IActionResult> Index()
    {
        var estoqueData = await _jsonDataService.GetEstoqueAsync();
        return View(estoqueData.Estoque);
    }
}

