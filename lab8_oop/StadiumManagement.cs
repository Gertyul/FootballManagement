public class StadiumManagement
{
    private List<Stadium> stadiums = new List<Stadium>();

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

    public List<Stadium> SearchStadiumByName(string name)
    {
        return stadiums.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
