using TargetSistemas.Models;

namespace TargetSistemas.Services;

public class JurosService
{
    private const decimal TaxaMultaDiaria = 0.025m;

    public static CalculoJurosViewModel CalcularJuros(decimal valorOriginal, DateTime dataVencimento)
    {
        var dataHoje = DateTime.Now.Date;
        var diasAtraso = Math.Max(0, (dataHoje - dataVencimento.Date).Days);

        var valorMulta = diasAtraso > 0 
            ? valorOriginal * TaxaMultaDiaria * diasAtraso 
            : 0;

        var valorTotalPagar = valorOriginal + valorMulta;

        return new CalculoJurosViewModel
        {
            ValorOriginal = valorOriginal,
            DataVencimento = dataVencimento,
            DiasAtraso = diasAtraso,
            ValorMulta = valorMulta,
            ValorTotalPagar = valorTotalPagar
        };
    }
}

