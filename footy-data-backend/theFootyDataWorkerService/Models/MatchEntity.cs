using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace theFootyDataWorkerService.Models
{
    public class MatchEntity
    {
        public int id { get; set; }
        public int? matchId { get; set; }
        public string? utcDate { get; set; }
        public string? status { get; set; }
        public int? matchday { get; set; }
        public string? homeTeam { get; set; }
        public string? awayTeam { get; set; }
        public string? halfTimeResult { get; set; }
        public string? fullTimeResult { get; set; }
        public string? winner { get; set; }
    }
}
