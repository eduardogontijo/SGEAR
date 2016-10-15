using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ADS.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Responsible { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public string Gender { get; set; }

        public void Delete()
        {
            this.Status = false;
        }
    }
}
