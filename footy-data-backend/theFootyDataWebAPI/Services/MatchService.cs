using System;
using theFootyDataWebAPI.Repository;
using theFootyDataWebAPI.Models;

namespace theFootyDataWebAPI.Services
{
	public class MatchService
	{
        private readonly IMatchRepository _matchRepository;

        public MatchService(IMatchRepository matchRepository)
		{
			_matchRepository = matchRepository;
		}

		public async Task<List<Match>> getMatches()
		{
			return await _matchRepository.getMatches();
		}
	}
}

