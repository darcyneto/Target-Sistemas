namespace TargetSistemas.Models;

public class Produto
{
    public int CodigoProduto { get; set; }
    public string DescricaoProduto { get; set; } = string.Empty;
    public int Estoque { get; set; }
}

public class EstoqueData
{
    public List<Produto> Estoque { get; set; } = new();
}

public class Movimentacao
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public int CodigoProduto { get; set; }
    public string TipoOperacao { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public DateTime DataMovimentacao { get; set; } = DateTime.Now;
}

public class MovimentacoesData
{
    public List<Movimentacao> Movimentacoes { get; set; } = new();
}

