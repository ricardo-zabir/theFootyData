using System;
using Microsoft.EntityFrameworkCore;
namespace theFootyDataWorkerService.Models
{
	public class Match
	{
		
        public int? id { get; set; }
        public Area? area { get; set; }
        public Competition? competition { get; set; }
        public Season? season { get; set; }
        public string? utcDate { get; set; }
        public string? status { get; set; }
        public int? matchday { get; set; }
        public string? stage { get; set; }
        public string? group { get; set; }
        public string? lastUpdated { get; set; }
        public Team? homeTeam { get; set; }
        public Team? awayTeam { get; set; }
        public Score? score { get; set; }
        public Odds? odds { get; set; }
        public List<Referee>? referees { get; set; }

    }
}

