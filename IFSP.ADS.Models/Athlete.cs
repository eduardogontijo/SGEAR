using System;
using System.Collections.Generic;

namespace IFSP.ADS.Models
{
    public class Athlete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public List<Match> Matches { get; set; }
        public User User { get; set; }

    }
}
