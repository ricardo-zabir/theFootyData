using System;
namespace theFootyDataWorkerService.Models
{
	public class Season
	{
		public int? id { get; set; }
        public string? startDate { get; set; }
        public string? endDate { get; set; }
        public int? currentMatchday { get; set; }
        public string? winner { get; set; }
    }
}

