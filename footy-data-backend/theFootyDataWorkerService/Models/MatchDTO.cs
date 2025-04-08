using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace theFootyDataWorkerService.Models
{
	public class MatchDTO
	{
        public int? matchId { get; set; }
		public string? utcDate { get; set; }
		public string? status { get; set; }
		public int? matchday { get; set; }
		public string? homeTeam { get; set; }
		public string? awayTeam { get; set; }
		public string? halfTimeResult { get; set; }
		public string? fullTimeResult { get; set; }
		public string? winner { get; set; }

		public MatchDTO()
		{

		}

		public MatchDTO(int? _id, string _utcDate, string _status, int? _matchday, string _homeTeam, string _awayTeam, string _halfTimeResult, string _fullTimeResult, string _winner )
		{
			matchId = _id;
			utcDate = _utcDate;
			status = _status;
			matchday = _matchday;
			homeTeam = _homeTeam;
			awayTeam = _awayTeam;
			halfTimeResult = _halfTimeResult;
			fullTimeResult = _fullTimeResult;
			winner = _winner;
		}

	}
}

