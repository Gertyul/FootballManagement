public class Player
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Status { get; set; }
    public string HealthStatus { get; set; }
    public decimal Salary { get; set; }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName}, Date of Birth: {DateOfBirth.ToShortDateString()}, Status: {Status}, Health Status: {HealthStatus}, Salary: {Salary:C}";
    }
}
