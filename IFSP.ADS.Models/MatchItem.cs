using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ADS.Models
{
    public class MatchItem
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public Athlete Athlete { get; set; }
        public Team Team { get; set; }
        public MatchItemType MatchItemType { get; set; }
    }
}
