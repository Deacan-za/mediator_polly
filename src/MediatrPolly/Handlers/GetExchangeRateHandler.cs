using MediatR;
using MediatrPolly.Services;

namespace MediatrPolly.Handlers;

/// <summary>
/// 
/// </summary>
internal sealed class GetExchangeRateQuery : IRequest<decimal>
{
    /// <summary>
    /// 
    /// </summary>
    public string? Currency { get; set; }
}

/// <summary>
/// GetExchangeRateHandler
/// </summary>
internal sealed class GetExchangeRateHandler : IRequestHandler<GetExchangeRateQuery, decimal>
{
    private readonly IExchangeRateService _exchangeRateService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="exchangeRateService"></param>
    public GetExchangeRateHandler(IExchangeRateService exchangeRateService)
    {
        _exchangeRateService = exchangeRateService;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<decimal> Handle(GetExchangeRateQuery request, CancellationToken cancellationToken)
    {
        return await _exchangeRateService.GetExchangeRateAsync(request.Currency).ConfigureAwait(false);
    }
}
