using System;
using System.Collections.Generic;
using System.Linq;

namespace lab8_oop
{
    public class FootballManagement
    {
        private List<Player> players = new List<Player>();
        private List<Game> games = new List<Game>();
        private List<Stadium> stadiums = new List<Stadium>();

        public void AddPlayer(Player player) => players.Add(player);
        public void RemovePlayer(Player player) => players.Remove(player);
        public void UpdatePlayer(Player player, string firstName, string lastName, DateTime? birthDate, string status, string healthStatus, decimal? salary)
        {
            if (firstName != null) player.FirstName = firstName;
            if (lastName != null) player.LastName = lastName;
            if (birthDate != null) player.BirthDate = birthDate.Value;
            if (status != null) player.Status = status;
            if (healthStatus != null) player.HealthStatus = healthStatus;
            if (salary != null) player.Salary = salary.Value;
        }
        public Player GetPlayerInfo(string firstName, string lastName) => players.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);
        public List<Player> GetAllPlayers() => players;

        public void AddGame(Game game)
        {
            games.Add(game);
            var stadium = stadiums.FirstOrDefault(s => s.Name == game.Venue);
            if (stadium != null)
            {
                stadium.Games.Add(game);
            }
        }

        public void RemoveGame(Game game)
        {
            games.Remove(game);
            var stadium = stadiums.FirstOrDefault(s => s.Name == game.Venue);
            if (stadium != null)
            {
                stadium.Games.Remove(game);
            }
        }

        public void UpdateGame(Game game, DateTime? newDate = null, string newVenue = null, int? newSpectators = null, string newResult = null)
        {
            if (newDate.HasValue)
            {
                game.Date = newDate.Value;
            }
            if (!string.IsNullOrEmpty(newVenue))
            {
                var oldStadium = stadiums.FirstOrDefault(s => s.Name == game.Venue);
                var newStadium = stadiums.FirstOrDefault(s => s.Name == newVenue);
                if (oldStadium != null)
                {
                    oldStadium.Games.Remove(game);
                }
                if (newStadium != null)
                {
                    newStadium.Games.Add(game);
                    game.Venue = newVenue;
                }
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
        public void AddPlayerToGame(Game game, Player player) => game.Players.Add(player);
        public void RemovePlayerFromGame(Game game, Player player) => game.Players.Remove(player);

        public void AddStadium(Stadium stadium)
        {
            stadiums.Add(stadium);
        }

        public void RemoveStadium(Stadium stadium)
        {
            stadiums.Remove(stadium);
        }

        public void UpdateStadium(Stadium stadium, int? newCapacity, decimal? newPricePerSeat)
        {
            if (newCapacity.HasValue)
            {
                stadium.Capacity = newCapacity.Value;
            }
            if (newPricePerSeat.HasValue)
            {
                stadium.PricePerSeat = newPricePerSeat.Value;
            }
        }

        public Stadium GetStadiumInfo(string name)
        {
            return stadiums.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Stadium> GetAllStadiums()
        {
            return stadiums;
        }

        public List<Player> SearchPlayerByName(string name)
        {
            return players.Where(p => p.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                                       p.LastName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Game> SearchGameByDateAndOpponent(DateTime date, string opponent)
        {
            return games.Where(g => g.Date == date && g.Opponent.Equals(opponent, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Stadium> SearchStadiumByName(string name)
        {
            return stadiums.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var footballManagement = new FootballManagement();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Football Management System");
                Console.WriteLine("1. Manage Players");
                Console.WriteLine("2. Manage Games");
                Console.WriteLine("3. Manage Stadiums");
                Console.WriteLine("4. Search");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManagePlayers(footballManagement);
                        break;
                    case "2":
                        ManageGames(footballManagement);
                        break;
                    case "3":
                        ManageStadiums(footballManagement);
                        break;
                    case "4":
                        Search(footballManagement);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void ManagePlayers(FootballManagement footballManagement)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Player Management");
                Console.WriteLine("1. Add Player");
                Console.WriteLine("2. Remove Player");
                Console.WriteLine("3. Update Player");
                Console.WriteLine("4. View Player Information");
                Console.WriteLine("5. View All Players");
                Console.WriteLine("6. Back");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPlayer(footballManagement);
                        break;
                    case "2":
                        RemovePlayer(footballManagement);
                        break;
                    case "3":
                        UpdatePlayer(footballManagement);
                        break;
                    case "4":
                        ViewPlayerInfo(footballManagement);
                        break;
                    case "5":
                        ViewAllPlayers(footballManagement);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddPlayer(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("Add Player");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Birth Date (yyyy-mm-dd): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
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
                BirthDate = birthDate,
                Status = status,
                HealthStatus = healthStatus,
                Salary = salary
            };

            footballManagement.AddPlayer(player);
            Console.WriteLine("Player added successfully.");
            Console.ReadLine();
        }

        static void RemovePlayer(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("Remove Player");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            var player = footballManagement.GetPlayerInfo(firstName, lastName);
            if (player != null)
            {
                footballManagement.RemovePlayer(player);
                Console.WriteLine("Player removed successfully.");
            }
            else
            {
                Console.WriteLine("Player not found.");
            }
            Console.ReadLine();
        }

        static void UpdatePlayer(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("Update Player");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            var player = footballManagement.GetPlayerInfo(firstName, lastName);
            if (player != null)
            {
                Console.WriteLine("Leave fields empty to keep current value.");

                Console.Write($"New First Name (current: {player.FirstName}): ");
                string newFirstName = Console.ReadLine();
                Console.Write($"New Last Name (current: {player.LastName}): ");
                string newLastName = Console.ReadLine();
                Console.Write($"New Birth Date (current: {player.BirthDate.ToShortDateString()}): ");
                string newBirthDate = Console.ReadLine();
                Console.Write($"New Status (current: {player.Status}): ");
                string newStatus = Console.ReadLine();
                Console.Write($"New Health Status (current: {player.HealthStatus}): ");
                string newHealthStatus = Console.ReadLine();
                Console.Write($"New Salary (current: {player.Salary:C}): ");
                string newSalary = Console.ReadLine();

                footballManagement.UpdatePlayer(player,
                                                 string.IsNullOrWhiteSpace(newFirstName) ? null : newFirstName,
                                                 string.IsNullOrWhiteSpace(newLastName) ? null : newLastName,
                                                 string.IsNullOrWhiteSpace(newBirthDate) ? (DateTime?)null : DateTime.Parse(newBirthDate),
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

        static void ViewPlayerInfo(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("View Player Information");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            var player = footballManagement.GetPlayerInfo(firstName, lastName);
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

        static void ViewAllPlayers(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("All Players");

            var players = footballManagement.GetAllPlayers();
            foreach (var player in players)
            {
                Console.WriteLine(player);
            }
            Console.ReadLine();
        }

        static void ManageGames(FootballManagement footballManagement)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Game Management");
                Console.WriteLine("1. Add Game");
                Console.WriteLine("2. Remove Game");
                Console.WriteLine("3. Update Game");
                Console.WriteLine("4. View Game Information");
                Console.WriteLine("5. View All Games");
                Console.WriteLine("6. Sort Games by Date");
                Console.WriteLine("7. Sort Games by Result");
                Console.WriteLine("8. Back");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddGame(footballManagement);
                        break;
                    case "2":
                        RemoveGame(footballManagement);
                        break;
                    case "3":
                        UpdateGame(footballManagement);
                        break;
                    case "4":
                        ViewGameInfo(footballManagement);
                        break;
                    case "5":
                        ViewAllGames(footballManagement);
                        break;
                    case "6":
                        SortGamesByDate(footballManagement);
                        break;
                    case "7":
                        SortGamesByResult(footballManagement);
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddGame(FootballManagement footballManagement)
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

            var game = new Game
            {
                Date = date,
                Opponent = opponent,
                Venue = venue,
                Spectators = spectators,
                Result = null
            };

            footballManagement.AddGame(game);
            Console.WriteLine("Game added successfully.");
            Console.ReadLine();
        }


        static void RemoveGame(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("Remove Game");

            Console.Write("Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Opponent: ");
            string opponent = Console.ReadLine();

            var game = footballManagement.GetGameInfo(date, opponent);
            if (game != null)
            {
                footballManagement.RemoveGame(game);
                Console.WriteLine("Game removed successfully.");
            }
            else
            {
                Console.WriteLine("Game not found.");
            }
            Console.ReadLine();
        }

        static void UpdateGame(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("Update Game");

            Console.Write("Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Opponent: ");
            string opponent = Console.ReadLine();

            var game = footballManagement.GetGameInfo(date, opponent);
            if (game != null)
            {
                Console.WriteLine("Leave fields empty to keep current value.");

                Console.Write($"New Date (current: {game.Date:yyyy-MM-dd}): ");
                string newDate = Console.ReadLine();
                Console.Write("New Venue: ");
                string newVenue = Console.ReadLine();
                Console.Write($"New Spectators (current: {game.Spectators}): ");
                string newSpectators = Console.ReadLine();
                Console.Write("New Result: ");
                string newResult = Console.ReadLine();

                footballManagement.UpdateGame(game,
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


        static void ViewGameInfo(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("View Game Information");

            Console.Write("Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Opponent: ");
            string opponent = Console.ReadLine();

            var game = footballManagement.GetGameInfo(date, opponent);
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

        static void ViewAllGames(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("All Games");

            var games = footballManagement.GetAllGames();
            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
            Console.ReadLine();
        }

        static void SortGamesByDate(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("Games Sorted by Date");

            var games = footballManagement.GetAllGames().OrderBy(g => g.Date).ToList();
            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
            Console.ReadLine();
        }

        static void SortGamesByResult(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("Games Sorted by Result");

            var games = footballManagement.GetAllGames();
            var wonGames = games.Where(g => g.Result == "Won").ToList();
            var lostGames = games.Where(g => g.Result == "Lost").ToList();
            var drawGames = games.Where(g => g.Result == "Draw").ToList();
            var yetToBePlayedGames = games.Where(g => g.Result == "Yet to be played").ToList();

            Console.WriteLine("Won Games:");
            foreach (var game in wonGames)
            {
                Console.WriteLine(game);
            }

            Console.WriteLine("\nLost Games:");
            foreach (var game in lostGames)
            {
                Console.WriteLine(game);
            }

            Console.WriteLine("\nDraw Games:");
            foreach (var game in drawGames)
            {
                Console.WriteLine(game);
            }

            Console.WriteLine("\nYet to be Played Games:");
            foreach (var game in yetToBePlayedGames)
            {
                Console.WriteLine(game);
            }

            Console.ReadLine();
        }

        static void ManageStadiums(FootballManagement footballManagement)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Stadium Management");
                Console.WriteLine("1. Add Stadium");
                Console.WriteLine("2. Remove Stadium");
                Console.WriteLine("3. Update Stadium");
                Console.WriteLine("4. View Stadium Information");
                Console.WriteLine("5. View All Stadiums");
                Console.WriteLine("6. Back");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStadium(footballManagement);
                        break;
                    case "2":
                        RemoveStadium(footballManagement);
                        break;
                    case "3":
                        UpdateStadium(footballManagement);
                        break;
                    case "4":
                        ViewStadiumInfo(footballManagement);
                        break;
                    case "5":
                        ViewAllStadiums(footballManagement);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddStadium(FootballManagement footballManagement)
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

            footballManagement.AddStadium(stadium);
            Console.WriteLine("Stadium added successfully.");
            Console.ReadLine();
        }


        static void RemoveStadium(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("Remove Stadium");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            var stadium = footballManagement.GetStadiumInfo(name);
            if (stadium != null)
            {
                footballManagement.RemoveStadium(stadium);
                Console.WriteLine("Stadium removed successfully.");
            }
            else
            {
                Console.WriteLine("Stadium not found.");
            }
            Console.ReadLine();
        }

        static void UpdateStadium(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("Update Stadium");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            var stadium = footballManagement.GetStadiumInfo(name);
            if (stadium != null)
            {
                Console.WriteLine("Leave fields empty to keep current value.");

                Console.Write($"New Capacity (current: {stadium.Capacity}): ");
                string newCapacity = Console.ReadLine();
                Console.Write($"New Price per Seat (current: {stadium.PricePerSeat:C}): ");
                string newPricePerSeat = Console.ReadLine();

                footballManagement.UpdateStadium(stadium,
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

        static void ViewStadiumInfo(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("View Stadium Information");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            var stadium = footballManagement.GetStadiumInfo(name);
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

        static void ViewAllStadiums(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("All Stadiums");

            var stadiums = footballManagement.GetAllStadiums();
            foreach (var stadium in stadiums)
            {
                Console.WriteLine(stadium);
            }
            Console.ReadLine();
        }

        static void Search(FootballManagement footballManagement)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Search");
                Console.WriteLine("1. Search Player by Name");
                Console.WriteLine("2. Search Game by Date and Opponent");
                Console.WriteLine("3. Search Stadium by Name");
                Console.WriteLine("4. Back");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SearchPlayerByName(footballManagement);
                        break;
                    case "2":
                        SearchGameByDateAndOpponent(footballManagement);
                        break;
                    case "3":
                        SearchStadiumByName(footballManagement);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void SearchPlayerByName(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("Search Player by Name");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            var players = footballManagement.SearchPlayerByName(name);
            foreach (var player in players)
            {
                Console.WriteLine(player);
            }
            Console.ReadLine();
        }

        static void SearchGameByDateAndOpponent(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("Search Game by Date and Opponent");

            Console.Write("Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Opponent: ");
            string opponent = Console.ReadLine();

            var games = footballManagement.SearchGameByDateAndOpponent(date, opponent);
            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
            Console.ReadLine();
        }

        static void SearchStadiumByName(FootballManagement footballManagement)
        {
            Console.Clear();
            Console.WriteLine("Search Stadium by Name");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            var stadiums = footballManagement.SearchStadiumByName(name);
            foreach (var stadium in stadiums)
            {
                Console.WriteLine(stadium);
            }
            Console.ReadLine();
        }
    }
}