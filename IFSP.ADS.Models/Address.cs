using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ADS.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Zip { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string Zone { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }
}
