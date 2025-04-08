using System;
using theFootyDataWorkerService.Models;

namespace theFootyDataWorkerService.Repository
{
	public interface IMatchRepository
	{
		public Task<MatchEntity> addMatch(MatchDTO matchData);
		public Task<MatchEntity?> getMatchById(int? id);
		public Task<MatchEntity?> updateMatch(int? id, MatchDTO matchData);
	}
}

