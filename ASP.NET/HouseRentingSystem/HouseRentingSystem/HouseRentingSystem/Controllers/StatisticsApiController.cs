using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers;
[Route("api/statistics")]
[ApiController]
public class StatisticsApiController : ControllerBase
{
	private readonly IStatisticsService _statisticsService;

	public StatisticsApiController(IStatisticsService statisticsService)
	{
		_statisticsService = statisticsService;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var statistics = await _statisticsService.TotalAsync();
		return Ok(statistics);
	}
}
