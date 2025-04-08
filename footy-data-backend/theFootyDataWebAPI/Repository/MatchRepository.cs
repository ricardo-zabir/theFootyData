using System;
using theFootyDataWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using theFootyDataWebAPI.Models;

namespace theFootyDataWebAPI.Repository
{
	public class MatchRepository : IMatchRepository
	{
        private readonly footyDbContext _context;

        public MatchRepository(footyDbContext context)
		{
			_context = context;
		}

		public async Task<List<Match>> getMatches()
		{
			return await _context.Matches.AsNoTracking().ToListAsync();
		}
	}
}

