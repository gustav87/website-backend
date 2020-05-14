using System.Threading.Tasks;
using MongoDB.Driver;
using W3ChampionsStatisticService.PlayerStats.HeroStats;
using W3ChampionsStatisticService.PlayerStats.RaceOnMapVersusRaceStats;
using W3ChampionsStatisticService.Ports;
using W3ChampionsStatisticService.ReadModelBase;

namespace W3ChampionsStatisticService.PlayerStats
{
    public class PlayerStatsRepository : MongoDbRepositoryBase, IPlayerStatsRepository
    {
        public Task<PlayerRaceOnMapVersusRaceRatio> LoadMapAndRaceStat(string battleTag, int season)
        {
            return LoadFirst<PlayerRaceOnMapVersusRaceRatio>(p => p.Id == battleTag && p.Season == season);
        }

        public Task<PlayerHeroStats> LoadHeroStat(string battleTag, int season)
        {
            return LoadFirst<PlayerHeroStats>(p => p.Id == battleTag && p.Season == season);
        }

        public Task UpsertMapAndRaceStat(PlayerRaceOnMapVersusRaceRatio playerRaceOnMapVersusRaceRatio)
        {
            return Upsert(playerRaceOnMapVersusRaceRatio, p => p.Id == playerRaceOnMapVersusRaceRatio.Id && p.Season == playerRaceOnMapVersusRaceRatio.Season);
        }

        public Task UpsertPlayerHeroStats(PlayerHeroStats playerHeroStats)
        {
            return Upsert(playerHeroStats, p => p.Id == playerHeroStats.Id && p.Season == playerHeroStats.Season);
        }

        public PlayerStatsRepository(MongoClient mongoClient) : base(mongoClient)
        {
        }
    }
}