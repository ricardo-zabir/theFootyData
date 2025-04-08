using System;
using theFootyDataWorkerService.Models;
using Microsoft.EntityFrameworkCore;

namespace theFootyDataWorkerService.Repository
{
    public class MatchRepository : IMatchRepository
    {

        private readonly footyDbContext _context;

        public MatchRepository(footyDbContext context)
        {
            _context = context;
        }

        public async Task<MatchEntity> addMatch(MatchDTO matchData)
        {
            MatchEntity match = new MatchEntity
            {
                matchId = matchData.matchId,
                utcDate = matchData.utcDate,
                status = matchData.status,
                matchday = matchData.matchday,
                homeTeam = matchData.homeTeam,
                awayTeam = matchData.awayTeam,
                halfTimeResult = matchData.halfTimeResult,
                fullTimeResult = matchData.fullTimeResult,
                winner = matchData.winner
            };

            await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();

            return match;
        }

        public async Task<MatchEntity?> getMatchById(int? id)
        {
            MatchEntity? match = await _context.Matches.FirstOrDefaultAsync(m => m.matchId == id);
            return match;
        }

        public async Task<MatchEntity> updateMatch (int? id, MatchDTO matchData)
        {
            MatchEntity match = await _context.Matches.FirstOrDefaultAsync(m => m.matchId == id);
            match.status = matchData.status;
            match.halfTimeResult = matchData.halfTimeResult;
            match.fullTimeResult = matchData.fullTimeResult;
            match.winner = matchData.winner;

            await _context.SaveChangesAsync();

            return match;
        }
    }
}

