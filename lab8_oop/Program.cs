class Program
{
    static void Main()
    {
        var playerManagement = new PlayerManagement();
        var gameManagement = new GameManagement();
        var stadiumManagement = new StadiumManagement();

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Football Management System");
            Console.WriteLine("1. Manage Players");
            Console.WriteLine("2. Manage Games");
            Console.WriteLine("3. Manage Stadiums");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ManagePlayers(playerManagement);
                    break;
                case "2":
                    ManageGames(gameManagement);
                    break;
                case "3":
                    ManageStadiums(stadiumManagement);
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void ManagePlayers(PlayerManagement playerManagement)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Manage Players");
            Console.WriteLine("1. Add Player");
            Console.WriteLine("2. Remove Player");
            Console.WriteLine("3. Update Player");
            Console.WriteLine("4. View Player Info");
            Console.WriteLine("5. View All Players");
            Console.WriteLine("6. Back");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddPlayer(playerManagement);
                    break;
                case "2":
                    RemovePlayer(playerManagement);
                    break;
                case "3":
                    UpdatePlayer(playerManagement);
                    break;
                case "4":
                    ViewPlayerInfo(playerManagement);
                    break;
                case "5":
                    ViewAllPlayers(playerManagement);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void AddPlayer(PlayerManagement playerManagement)
    {
        Console.Clear();
        Console.WriteLine("Add Player");

        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();
        Console.Write("Date of Birth (yyyy-mm-dd): ");
        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
        Console.Write("Status: ");
        string status = Console.ReadLine();
        Console.Write("Health Status: ");
        string healthStatus = Console.ReadLine();
        Console.Write("Salary: ");
        decimal salary = decimal.Parse(Console.ReadLine());

        var player = new Player
        {
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth,
            Status = status,
            HealthStatus = healthStatus,
            Salary = salary
        };

        playerManagement.AddPlayer(player);
        Console.WriteLine("Player added successfully.");
        Console.ReadLine();
    }

    static void RemovePlayer(PlayerManagement playerManagement)
    {
        Console.Clear();
        Console.WriteLine("Remove Player");

        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        var player = playerManagement.GetPlayerInfo(firstName, lastName);
        if (player != null)
        {
            playerManagement.RemovePlayer(player);
            Console.WriteLine("Player removed successfully.");
        }
        else
        {
            Console.WriteLine("Player not found.");
        }
        Console.ReadLine();
    }

    static void UpdatePlayer(PlayerManagement playerManagement)
    {
        Console.Clear();
        Console.WriteLine("Update Player");

        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        var player = playerManagement.GetPlayerInfo(firstName, lastName);
        if (player != null)
        {
            Console.WriteLine("Leave fields empty to keep current value.");

            Console.Write($"New First Name (current: {player.FirstName}): ");
            string newFirstName = Console.ReadLine();
            Console.Write($"New Last Name (current: {player.LastName}): ");
            string newLastName = Console.ReadLine();
            Console.Write($"New Date of Birth (current: {player.DateOfBirth:yyyy-MM-dd}): ");
            string newDateOfBirth = Console.ReadLine();
            Console.Write($"New Status (current: {player.Status}): ");
            string newStatus = Console.ReadLine();
            Console.Write($"New Health Status (current: {player.HealthStatus}): ");
            string newHealthStatus = Console.ReadLine();
            Console.Write($"New Salary (current: {player.Salary}): ");
            string newSalary = Console.ReadLine();

            playerManagement.UpdatePlayer(player,
                                          string.IsNullOrWhiteSpace(newFirstName) ? null : newFirstName,
                                          string.IsNullOrWhiteSpace(newLastName) ? null : newLastName,
                                          string.IsNullOrWhiteSpace(newDateOfBirth) ? (DateTime?)null : DateTime.Parse(newDateOfBirth),
                                          string.IsNullOrWhiteSpace(newStatus) ? null : newStatus,
                                          string.IsNullOrWhiteSpace(newHealthStatus) ? null : newHealthStatus,
                                          string.IsNullOrWhiteSpace(newSalary) ? (decimal?)null : decimal.Parse(newSalary));

            Console.WriteLine("Player updated successfully.");
        }
        else
        {
            Console.WriteLine("Player not found.");
        }
        Console.ReadLine();
    }

    static void ViewPlayerInfo(PlayerManagement playerManagement)
    {
        Console.Clear();
        Console.WriteLine("View Player Information");

        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        var player = playerManagement.GetPlayerInfo(firstName, lastName);
        if (player != null)
        {
            Console.WriteLine(player);
        }
        else
        {
            Console.WriteLine("Player not found.");
        }
        Console.ReadLine();
    }

    static void ViewAllPlayers(PlayerManagement playerManagement)
    {
        Console.Clear();
        Console.WriteLine("All Players");

        var players = playerManagement.GetAllPlayers();
        foreach (var player in players)
        {
            Console.WriteLine(player);
        }
        Console.ReadLine();
    }

    static void ManageGames(GameManagement gameManagement)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Manage Games");
            Console.WriteLine("1. Add Game");
            Console.WriteLine("2. Remove Game");
            Console.WriteLine("3. Update Game");
            Console.WriteLine("4. View Game Info");
            Console.WriteLine("5. View All Games");
            Console.WriteLine("6. Sort Games by Date");
            Console.WriteLine("7. Sort Games by Result");
            Console.WriteLine("8. Back");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddGame(gameManagement);
                    break;
                case "2":
                    RemoveGame(gameManagement);
                    break;
                case "3":
                    UpdateGame(gameManagement);
                    break;
                case "4":
                    ViewGameInfo(gameManagement);
                    break;
                case "5":
                    ViewAllGames(gameManagement);
                    break;
                case "6":
                    SortGamesByDate(gameManagement);
                    break;
                case "7":
                    SortGamesByResult(gameManagement);
                    break;
                case "8":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void AddGame(GameManagement gameManagement)
    {
        Console.Clear();
        Console.WriteLine("Add Game");

        Console.Write("Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.Write("Opponent: ");
        string opponent = Console.ReadLine();
        Console.Write("Venue: ");
        string venue = Console.ReadLine();
        Console.Write("Spectators: ");
        int spectators = int.Parse(Console.ReadLine());
        Console.Write("Result: ");
        string result = Console.ReadLine();

        var game = new Game
        {
            Date = date,
            Opponent = opponent,
            Venue = venue,
            Spectators = spectators,
            Result = result
        };

        gameManagement.AddGame(game);
        Console.WriteLine("Game added successfully.");
        Console.ReadLine();
    }

    static void RemoveGame(GameManagement gameManagement)
    {
        Console.Clear();
        Console.WriteLine("Remove Game");

        Console.Write("Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.Write("Opponent: ");
        string opponent = Console.ReadLine();

        var game = gameManagement.GetGameInfo(date, opponent);
        if (game != null)
        {
            gameManagement.RemoveGame(game);
            Console.WriteLine("Game removed successfully.");
        }
        else
        {
            Console.WriteLine("Game not found.");
        }
        Console.ReadLine();
    }

    static void UpdateGame(GameManagement gameManagement)
    {
        Console.Clear();
        Console.WriteLine("Update Game");

        Console.Write("Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.Write("Opponent: ");
        string opponent = Console.ReadLine();

        var game = gameManagement.GetGameInfo(date, opponent);
        if (game != null)
        {
            Console.WriteLine("Leave fields empty to keep current value.");

            Console.Write($"New Date (current: {game.Date:yyyy-MM-dd}): ");
            string newDate = Console.ReadLine();
            Console.Write($"New Venue (current: {game.Venue}): ");
            string newVenue = Console.ReadLine();
            Console.Write($"New Spectators (current: {game.Spectators}): ");
            string newSpectators = Console.ReadLine();
            Console.Write($"New Result (current: {game.Result}): ");
            string newResult = Console.ReadLine();

            gameManagement.UpdateGame(game,
                                      string.IsNullOrWhiteSpace(newDate) ? (DateTime?)null : DateTime.Parse(newDate),
                                      string.IsNullOrWhiteSpace(newVenue) ? null : newVenue,
                                      string.IsNullOrWhiteSpace(newSpectators) ? (int?)null : int.Parse(newSpectators),
                                      string.IsNullOrWhiteSpace(newResult) ? null : newResult);

            Console.WriteLine("Game updated successfully.");
        }
        else
        {
            Console.WriteLine("Game not found.");
        }
        Console.ReadLine();
    }

    static void ViewGameInfo(GameManagement gameManagement)
    {
        Console.Clear();
        Console.WriteLine("View Game Information");

        Console.Write("Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.Write("Opponent: ");
        string opponent = Console.ReadLine();

        var game = gameManagement.GetGameInfo(date, opponent);
        if (game != null)
        {
            Console.WriteLine(game);
        }
        else
        {
            Console.WriteLine("Game not found.");
        }
        Console.ReadLine();
    }

    static void ViewAllGames(GameManagement gameManagement)
    {
        Console.Clear();
        Console.WriteLine("All Games");

        var games = gameManagement.GetAllGames();
        foreach (var game in games)
        {
            Console.WriteLine(game);
        }
        Console.ReadLine();
    }

    static void SortGamesByDate(GameManagement gameManagement)
    {
        Console.Clear();
        Console.WriteLine("Games Sorted by Date");

        var games = gameManagement.GetGamesSortedByDate();
        foreach (var game in games)
        {
            Console.WriteLine(game);
        }
        Console.ReadLine();
    }

    static void SortGamesByResult(GameManagement gameManagement)
    {
        Console.Clear();
        Console.WriteLine("Games Sorted by Result");

        var sortedGames = gameManagement.GetGamesSortedByResult();
        foreach (var category in sortedGames.Keys)
        {
            Console.WriteLine(category + ":");
            foreach (var game in sortedGames[category])
            {
                Console.WriteLine("  " + game);
            }
        }
        Console.ReadLine();
    }

    static void ManageStadiums(StadiumManagement stadiumManagement)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Manage Stadiums");
            Console.WriteLine("1. Add Stadium");
            Console.WriteLine("2. Remove Stadium");
            Console.WriteLine("3. Update Stadium");
            Console.WriteLine("4. View Stadium Info");
            Console.WriteLine("5. View All Stadiums");
            Console.WriteLine("6. Back");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddStadium(stadiumManagement);
                    break;
                case "2":
                    RemoveStadium(stadiumManagement);
                    break;
                case "3":
                    UpdateStadium(stadiumManagement);
                    break;
                case "4":
                    ViewStadiumInfo(stadiumManagement);
                    break;
                case "5":
                    ViewAllStadiums(stadiumManagement);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void AddStadium(StadiumManagement stadiumManagement)
    {
        Console.Clear();
        Console.WriteLine("Add Stadium");

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Capacity: ");
        int capacity = int.Parse(Console.ReadLine());
        Console.Write("Price per Seat: ");
        decimal pricePerSeat = decimal.Parse(Console.ReadLine());

        var stadium = new Stadium
        {
            Name = name,
            Capacity = capacity,
            PricePerSeat = pricePerSeat
        };

        stadiumManagement.AddStadium(stadium);
        Console.WriteLine("Stadium added successfully.");
        Console.ReadLine();
    }

    static void RemoveStadium(StadiumManagement stadiumManagement)
    {
        Console.Clear();
        Console.WriteLine("Remove Stadium");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        var stadium = stadiumManagement.GetStadiumInfo(name);
        if (stadium != null)
        {
            stadiumManagement.RemoveStadium(stadium);
            Console.WriteLine("Stadium removed successfully.");
        }
        else
        {
            Console.WriteLine("Stadium not found.");
        }
        Console.ReadLine();
    }

    static void UpdateStadium(StadiumManagement stadiumManagement)
    {
        Console.Clear();
        Console.WriteLine("Update Stadium");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        var stadium = stadiumManagement.GetStadiumInfo(name);
        if (stadium != null)
        {
            Console.WriteLine("Leave fields empty to keep current value.");

            Console.Write($"New Capacity (current: {stadium.Capacity}): ");
            string newCapacity = Console.ReadLine();
            Console.Write($"New Price per Seat (current: {stadium.PricePerSeat:C}): ");
            string newPricePerSeat = Console.ReadLine();

            stadiumManagement.UpdateStadium(stadium,
                                            string.IsNullOrWhiteSpace(newCapacity) ? (int?)null : int.Parse(newCapacity),
                                            string.IsNullOrWhiteSpace(newPricePerSeat) ? (decimal?)null : decimal.Parse(newPricePerSeat));

            Console.WriteLine("Stadium updated successfully.");
        }
        else
        {
            Console.WriteLine("Stadium not found.");
        }
        Console.ReadLine();
    }

    static void ViewStadiumInfo(StadiumManagement stadiumManagement)
    {
        Console.Clear();
        Console.WriteLine("View Stadium Information");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        var stadium = stadiumManagement.GetStadiumInfo(name);
        if (stadium != null)
        {
            Console.WriteLine(stadium);
        }
        else
        {
            Console.WriteLine("Stadium not found.");
        }
        Console.ReadLine();
    }

    static void ViewAllStadiums(StadiumManagement stadiumManagement)
    {
        Console.Clear();
        Console.WriteLine("All Stadiums");

        var stadiums = stadiumManagement.GetAllStadiums();
        foreach (var stadium in stadiums)
        {
            Console.WriteLine(stadium);
        }
        Console.ReadLine();
    }
}
