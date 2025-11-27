using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TargetSistemas.Models;

namespace TargetSistemas.Services;

public class JsonDataService : IJsonDataService
{
    private readonly JsonDataOptions _options;

    public JsonDataService(IOptions<JsonDataOptions> options)
    {
        _options = options.Value;
    }

    public async Task InitializeAsync()
    {
        if (!File.Exists(_options.VendasPath))
        {
            var vendasIniciais = new VendasData
            {
                Vendas = new List<Venda>
                {
                    new() { Vendedor = "João Silva", Valor = 1200.50m },
                    new() { Vendedor = "João Silva", Valor = 950.75m },
                    new() { Vendedor = "João Silva", Valor = 1800.00m },
                    new() { Vendedor = "João Silva", Valor = 1400.30m },
                    new() { Vendedor = "João Silva", Valor = 1100.90m },
                    new() { Vendedor = "João Silva", Valor = 1550.00m },
                    new() { Vendedor = "João Silva", Valor = 1700.80m },
                    new() { Vendedor = "João Silva", Valor = 250.30m },
                    new() { Vendedor = "João Silva", Valor = 480.75m },
                    new() { Vendedor = "João Silva", Valor = 320.40m },
                    new() { Vendedor = "Maria Souza", Valor = 2100.40m },
                    new() { Vendedor = "Maria Souza", Valor = 1350.60m },
                    new() { Vendedor = "Maria Souza", Valor = 950.20m },
                    new() { Vendedor = "Maria Souza", Valor = 1600.75m },
                    new() { Vendedor = "Maria Souza", Valor = 1750.00m },
                    new() { Vendedor = "Maria Souza", Valor = 1450.90m },
                    new() { Vendedor = "Maria Souza", Valor = 400.50m },
                    new() { Vendedor = "Maria Souza", Valor = 180.20m },
                    new() { Vendedor = "Maria Souza", Valor = 90.75m },
                    new() { Vendedor = "Carlos Oliveira", Valor = 800.50m },
                    new() { Vendedor = "Carlos Oliveira", Valor = 1200.00m },
                    new() { Vendedor = "Carlos Oliveira", Valor = 1950.30m },
                    new() { Vendedor = "Carlos Oliveira", Valor = 1750.80m },
                    new() { Vendedor = "Carlos Oliveira", Valor = 1300.60m },
                    new() { Vendedor = "Carlos Oliveira", Valor = 300.40m },
                    new() { Vendedor = "Carlos Oliveira", Valor = 500.00m },
                    new() { Vendedor = "Carlos Oliveira", Valor = 125.75m },
                    new() { Vendedor = "Ana Lima", Valor = 1000.00m },
                    new() { Vendedor = "Ana Lima", Valor = 1100.50m },
                    new() { Vendedor = "Ana Lima", Valor = 1250.75m },
                    new() { Vendedor = "Ana Lima", Valor = 1400.20m },
                    new() { Vendedor = "Ana Lima", Valor = 1550.90m },
                    new() { Vendedor = "Ana Lima", Valor = 1650.00m },
                    new() { Vendedor = "Ana Lima", Valor = 75.30m },
                    new() { Vendedor = "Ana Lima", Valor = 420.90m },
                    new() { Vendedor = "Ana Lima", Valor = 315.40m }
                }
            };
            await SaveVendasAsync(vendasIniciais);
        }

        if (!File.Exists(_options.EstoquePath))
        {
            var estoqueInicial = new EstoqueData
            {
                Estoque = new List<Produto>
                {
                    new() { CodigoProduto = 101, DescricaoProduto = "Caneta Azul", Estoque = 150 },
                    new() { CodigoProduto = 102, DescricaoProduto = "Caderno Universitário", Estoque = 75 },
                    new() { CodigoProduto = 103, DescricaoProduto = "Borracha Branca", Estoque = 200 },
                    new() { CodigoProduto = 104, DescricaoProduto = "Lápis Preto HB", Estoque = 320 },
                    new() { CodigoProduto = 105, DescricaoProduto = "Marcador de Texto Amarelo", Estoque = 90 }
                }
            };
            await SaveEstoqueAsync(estoqueInicial);
        }

        if (!File.Exists(_options.MovimentacoesPath))
        {
            var movimentacoesIniciais = new MovimentacoesData
            {
                Movimentacoes = new List<Movimentacao>()
            };
            await SaveMovimentacoesAsync(movimentacoesIniciais);
        }
    }

    public async Task<VendasData> GetVendasAsync()
    {
        if (!File.Exists(_options.VendasPath))
        {
            return new VendasData();
        }

        var json = await File.ReadAllTextAsync(_options.VendasPath);
        return JsonConvert.DeserializeObject<VendasData>(json) ?? new VendasData();
    }

    public async Task SaveVendasAsync(VendasData data)
    {
        var json = JsonConvert.SerializeObject(data, Formatting.Indented);
        await File.WriteAllTextAsync(_options.VendasPath, json);
    }

    public async Task<EstoqueData> GetEstoqueAsync()
    {
        if (!File.Exists(_options.EstoquePath))
        {
            return new EstoqueData();
        }

        var json = await File.ReadAllTextAsync(_options.EstoquePath);
        return JsonConvert.DeserializeObject<EstoqueData>(json) ?? new EstoqueData();
    }

    public async Task SaveEstoqueAsync(EstoqueData data)
    {
        var json = JsonConvert.SerializeObject(data, Formatting.Indented);
        await File.WriteAllTextAsync(_options.EstoquePath, json);
    }

    public async Task<MovimentacoesData> GetMovimentacoesAsync()
    {
        if (!File.Exists(_options.MovimentacoesPath))
        {
            return new MovimentacoesData();
        }

        var json = await File.ReadAllTextAsync(_options.MovimentacoesPath);
        return JsonConvert.DeserializeObject<MovimentacoesData>(json) ?? new MovimentacoesData();
    }

    public async Task SaveMovimentacoesAsync(MovimentacoesData data)
    {
        var json = JsonConvert.SerializeObject(data, Formatting.Indented);
        await File.WriteAllTextAsync(_options.MovimentacoesPath, json);
    }
}

