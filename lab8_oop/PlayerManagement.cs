public class PlayerManagement
{
    private List<Player> players = new List<Player>();

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        players.Remove(player);
    }

    public void UpdatePlayer(Player player, string newFirstName, string newLastName, DateTime? newDateOfBirth, string newStatus, string newHealthStatus, decimal? newSalary)
    {
        if (!string.IsNullOrEmpty(newFirstName))
        {
            player.FirstName = newFirstName;
        }
        if (!string.IsNullOrEmpty(newLastName))
        {
            player.LastName = newLastName;
        }
        if (newDateOfBirth.HasValue)
        {
            player.DateOfBirth = newDateOfBirth.Value;
        }
        if (!string.IsNullOrEmpty(newStatus))
        {
            player.Status = newStatus;
        }
        if (!string.IsNullOrEmpty(newHealthStatus))
        {
            player.HealthStatus = newHealthStatus;
        }
        if (newSalary.HasValue)
        {
            player.Salary = newSalary.Value;
        }
    }

    public Player GetPlayerInfo(string firstName, string lastName)
    {
        return players.FirstOrDefault(p => p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                                            p.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
    }

    public List<Player> GetAllPlayers()
    {
        return players;
    }

    public List<Player> SearchPlayerByName(string name)
    {
        return players.Where(p => p.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                                   p.LastName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
