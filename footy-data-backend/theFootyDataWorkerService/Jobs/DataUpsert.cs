using System;
using Newtonsoft.Json;

using theFootyDataWorkerService.Models;
using theFootyDataWorkerService.Repository;

namespace theFootyDataWorkerService
{
	public class DataUpsert
	{
		private readonly IMatchRepository _matchRepository;

		public DataUpsert(IMatchRepository matchRepository)
		{
			_matchRepository = matchRepository;
		}

        public async Task<string> triggerDataUpsertFunc()
        {
            FootballDataResponse footballDataResponse = await getMatches();
            List<Match> matchesData = footballDataResponse.matches;
            List<MatchDTO> matches = prepareDTOs(matchesData);
            foreach (MatchDTO match in matches)
            {
				MatchEntity? dbMatch = await _matchRepository.getMatchById(match.matchId);
				if(dbMatch == null)
				{
					await _matchRepository.addMatch(match);
				}
				else
				{
					await _matchRepository.updateMatch(match.matchId,match);
				}
            }

            return "done";
        }

        public async Task<FootballDataResponse> getMatches()
		{
			HttpClientHandler handler = new HttpClientHandler();
			HttpClient httpClient = new HttpClient();

			DateTime today = DateTime.Today;
			DateTime lastWeek = today.AddDays(-7);
			DateTime nextWeek = today.AddDays(7);

			string parsedNextWeekDate = nextWeek.ToString("yyyy-MM-dd");
			string parsedLastWeekDate = lastWeek.ToString("yyyy-MM-dd");


			string url = $"http://api.football-data.org/v4/competitions/2016/matches?dateFrom={parsedLastWeekDate}&dateTo={parsedNextWeekDate}";
			string token = "9b889af669164b419b4c22d21d1f1c1f"; // mudar !

			httpClient.DefaultRequestHeaders.Add("X-Auth-Token", token);

			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
			HttpResponseMessage response = await httpClient.SendAsync(request);

			string responseBody = new StreamReader(await response.Content.ReadAsStreamAsync()).ReadToEnd();
			FootballDataResponse footballData = JsonConvert.DeserializeObject<FootballDataResponse>(responseBody);
			return footballData;
		}

		public List<MatchDTO> prepareDTOs(List<Match> matchesData)
		{
			List<MatchDTO> matches = new List<MatchDTO>();
			foreach(Match m in matchesData)
			{
				string halfTimeResult = "";
				string fullTimeResult = "";
				if(m.score.halfTime.home == null)
				{
                    halfTimeResult = "0" + " - " + "0";
                    fullTimeResult = "0" + " - " + "0";
                }
				else if(m.score.fullTime.home == null)
				{
                    halfTimeResult = m.score.halfTime.home.ToString() + " - " + m.score.halfTime.away.ToString();
					fullTimeResult = "0" + " - " + "0";
                }
				else
				{
                    halfTimeResult = m.score.halfTime.home.ToString() + " - " + m.score.halfTime.away.ToString();
                    fullTimeResult = m.score.fullTime.home.ToString() + " - " + m.score.fullTime.away.ToString();
                }
				MatchDTO match = new MatchDTO(m.id, m.utcDate, m.status, m.matchday, m.homeTeam.shortName, m.awayTeam.shortName, halfTimeResult, fullTimeResult, m.score.winner);

				matches.Add(match);

			}

			return matches;
		}


	}
}

