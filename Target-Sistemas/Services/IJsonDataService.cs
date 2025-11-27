using TargetSistemas.Models;

namespace TargetSistemas.Services;

public interface IJsonDataService
{
    Task InitializeAsync();
    Task<VendasData> GetVendasAsync();
    Task SaveVendasAsync(VendasData data);
    Task<EstoqueData> GetEstoqueAsync();
    Task SaveEstoqueAsync(EstoqueData data);
    Task<MovimentacoesData> GetMovimentacoesAsync();
    Task SaveMovimentacoesAsync(MovimentacoesData data);
}

