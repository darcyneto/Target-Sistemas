using Microsoft.AspNetCore.Mvc;
using TargetSistemas.Models;
using TargetSistemas.Services;

namespace TargetSistemas.Controllers;

public class JurosController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new CalculoJurosViewModel
        {
            DataVencimento = DateTime.Today
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Calcular(CalculoJurosViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", model);
        }

        var resultado = JurosService.CalcularJuros(model.ValorOriginal, model.DataVencimento);
        return View("Index", resultado);
    }
}

