using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_oop
{
    public class Stadium
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerSeat { get; set; }
        public List<Game> Games { get; set; } = new List<Game>();

        public override string ToString()
        {
            var gamesInfo = Games.Count > 0 ? string.Join("\n", Games.Select(g => $"  - {g.Date.ToShortDateString()}: {g.Opponent}")) : "  No games scheduled.";
            return $"Name: {Name}, Capacity: {Capacity}, Price per Seat: {PricePerSeat:C}\nScheduled Games:\n{gamesInfo}";
        }
    }
}
