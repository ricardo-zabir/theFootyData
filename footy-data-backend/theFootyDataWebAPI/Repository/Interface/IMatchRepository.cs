using System;
using theFootyDataWebAPI.Models;

namespace theFootyDataWebAPI.Repository
{
	public interface IMatchRepository
	{
		public Task<List<Match>> getMatches();
	}
}

