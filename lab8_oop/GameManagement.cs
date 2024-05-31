public class GameManagement
{
    private List<Game> games = new List<Game>();

    public void AddGame(Game game)
    {
        games.Add(game);
    }

    public void RemoveGame(Game game)
    {
        games.Remove(game);
    }

    public void UpdateGame(Game game, DateTime? newDate = null, string newVenue = null, int? newSpectators = null, string newResult = null)
    {
        if (newDate.HasValue)
        {
            game.Date = newDate.Value;
        }
        if (!string.IsNullOrEmpty(newVenue))
        {
            game.Venue = newVenue;
        }
        if (newSpectators.HasValue)
        {
            game.Spectators = newSpectators.Value;
        }
        if (!string.IsNullOrEmpty(newResult))
        {
            game.Result = newResult;
        }
    }

    public Game GetGameInfo(DateTime date, string opponent)
    {
        return games.FirstOrDefault(g => g.Date == date && g.Opponent.Equals(opponent, StringComparison.OrdinalIgnoreCase));
    }

    public List<Game> GetAllGames()
    {
        return games;
    }

    public List<Game> GetGamesSortedByDate()
    {
        return games.OrderBy(game => game.Date).ToList();
    }

    public Dictionary<string, List<Game>> GetGamesSortedByResult()
    {
        var sortedGames = new Dictionary<string, List<Game>>
        {
            { "Win", new List<Game>() },
            { "Lose", new List<Game>() },
            { "Draw", new List<Game>() },
            { "Not played yet", new List<Game>() }
        };

        foreach (var game in games)
        {
            if (game.Result == "Won" || game.Result == "Win" || game.Result == "won" || game.Result == "win")
            {
                sortedGames["Win"].Add(game);
            }
            else if (game.Result == "Lose" || game.Result == "lose")
            {
                sortedGames["Lose"].Add(game);
            }
            else if (game.Result == "Draw" || game.Result == "draw")
            {
                sortedGames["Draw"].Add(game);
            }
            else
            {
                sortedGames["Not played yet"].Add(game);
            }
        }

        return sortedGames;
    }

    public List<Game> SearchGameByDateAndOpponent(DateTime date, string opponent)
    {
        return games.Where(g => g.Date == date && g.Opponent.Equals(opponent, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
