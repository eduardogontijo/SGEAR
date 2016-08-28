using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ADS.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public MatchStatus Status { get; set; }
        public List<MatchItem> Items { get; set; }
        public List<Athlete> Athletes { get; set; }
        public Team Opponent { get; set; }
        public Team Team { get; set; }
        public Federation Federation { get; set; }
        public Field Field { get; set; }
        public int Winner { get; set; }

    }
}
