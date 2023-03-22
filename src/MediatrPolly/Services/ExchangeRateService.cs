namespace MediatrPolly.Services;

/// <summary>
/// 
/// </summary>
public sealed class ExchangeRateService: IExchangeRateService
{
  private readonly HttpClient _httpClient;

  /// <summary>
  /// 
  /// </summary>
  /// <param name="httpClient"></param>
  public ExchangeRateService(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="currency"></param>
  /// <returns></returns>
  public Task<decimal> GetExchangeRateAsync(string? currency)
  {
    return Task.FromResult(10.00m);
  }
}

/// <summary>
/// 
/// </summary>
public interface IExchangeRateService
{
  /// <summary>
  /// 
  /// </summary>
  /// <param name="currency"></param>
  /// <returns></returns>
  Task<decimal> GetExchangeRateAsync(string? currency);
}
