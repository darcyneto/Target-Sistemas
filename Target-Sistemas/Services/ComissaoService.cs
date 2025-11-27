using TargetSistemas.Models;

namespace TargetSistemas.Services;

public class ComissaoService
{
    public static decimal CalcularComissao(decimal valorVenda)
    {
        if (valorVenda < 100.00m)
        {
            return 0;
        }
        else if (valorVenda < 500.00m)
        {
            return valorVenda * 0.01m;
        }
        else
        {
            return valorVenda * 0.05m;
        }
    }

    public static List<ComissaoResultado> CalcularComissoesPorVendedor(List<Venda> vendas)
    {
        var resultado = vendas
            .GroupBy(v => v.Vendedor)
            .Select(g => new ComissaoResultado
            {
                Vendedor = g.Key,
                TotalVendas = g.Sum(v => v.Valor),
                TotalComissao = g.Sum(v => CalcularComissao(v.Valor))
            })
            .OrderBy(r => r.Vendedor)
            .ToList();

        return resultado;
    }
}

