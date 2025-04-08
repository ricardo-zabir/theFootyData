using System;
namespace theFootyDataWorkerService.Models
{
	public class FootballDataResponse
	{
		public Filter? filters { get; set; }
        public ResultSet? resultSet { get; set; }
        public Competition? competition { get; set; }
        public List<Match>? matches { get; set; }
    }
}

