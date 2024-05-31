public class Game
{
    public DateTime Date { get; set; }
    public string Opponent { get; set; }
    public string Venue { get; set; }
    public int Spectators { get; set; }
    public string Result { get; set; }

    public override string ToString()
    {
        return $"Date: {Date:yyyy-MM-dd}, Opponent: {Opponent}, Venue: {Venue}, Spectators: {Spectators}, Result: {Result}";
    }
}
