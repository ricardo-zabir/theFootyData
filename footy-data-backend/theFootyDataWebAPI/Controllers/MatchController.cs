using System;
using Microsoft.AspNetCore.Mvc;
using theFootyDataWebAPI.Models;
using theFootyDataWebAPI.Services;

namespace theFootyDataWebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MatchController : ControllerBase
	{
		private readonly MatchService _matchService;

		public MatchController(MatchService matchService)
		{
			_matchService = matchService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				List<Match> matches = await _matchService.getMatches();
				return Ok(matches);
			}
			catch(Exception ex)
			{
				Console.Write(ex.Message);
				return StatusCode(500);
			}
		}
	}
}

