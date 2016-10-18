using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ADS.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string AdditionalPhone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public bool Status { get; set; }

        public void Delete()
        {
            this.Status = false;
        }
    }
}
