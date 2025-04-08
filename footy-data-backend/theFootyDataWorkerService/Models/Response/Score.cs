using System;

namespace theFootyDataWorkerService.Models
{
	public class Score
	{
		public string? winner { get; set; }
        public string? duration { get; set; }
        public FullTime? fullTime { get; set; }
        public HalfTime? halfTime { get; set; }
        public int matchId { get; set; }
    }
}

