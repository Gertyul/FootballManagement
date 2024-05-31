using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_oop
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Status { get; set; }
        public string HealthStatus { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, Birth Date: {BirthDate.ToShortDateString()}, Status: {Status}, Health Status: {HealthStatus}, Salary: {Salary:C}";
        }
    }
}
