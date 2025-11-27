using System.ComponentModel.DataAnnotations;

namespace TargetSistemas.Models;

public class CalculoJurosViewModel
{
    [Required(ErrorMessage = "O valor original é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
    [Display(Name = "Valor Original")]
    public decimal ValorOriginal { get; set; }

    [Required(ErrorMessage = "A data de vencimento é obrigatória")]
    [Display(Name = "Data de Vencimento")]
    [DataType(DataType.Date)]
    public DateTime DataVencimento { get; set; }

    public int DiasAtraso { get; set; }
    public decimal ValorMulta { get; set; }
    public decimal ValorTotalPagar { get; set; }
}

