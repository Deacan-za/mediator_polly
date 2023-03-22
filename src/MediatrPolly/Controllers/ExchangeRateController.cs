using MediatR;
using MediatrPolly.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace MediatrPolly.Controllers
{
  /// <summary>
  /// Exchange Rate Controller
  /// </summary>
  [Route("exchangerate")]
  public class ExchangeRateController : ControllerBase
  {
    private readonly IMediator _mediator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public ExchangeRateController(IMediator mediator)
    {
      _mediator = mediator;
    }

    /// <summary>
    /// Get Exchange Rate
    /// </summary>
    /// <param name="currency"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getexchangerate/{currency}")]
    public async Task<IActionResult> GetExchangeRate(string currency)
    {
      var result = await _mediator.Send(new GetExchangeRateQuery
      {
        Currency = currency
      });

      return Ok(result);
    }
  }
}
