using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_oop
{
    public class Game
    {
        public DateTime Date { get; set; }
        public string Opponent { get; set; }
        public string Venue { get; set; }
        public int Spectators { get; set; }
        public string Result { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();

        public override string ToString()
        {
            return $"Date: {Date.ToShortDateString()}, Opponent: {Opponent}, Venue: {Venue}, Spectators: {Spectators}, Result: {Result}";
        }
    }
}
