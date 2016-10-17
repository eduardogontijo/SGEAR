using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ADS.Models
{
    public class Modality
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string CompetitionType { get; set; }

        public bool Status { get; set; } = true;

        public void Delete()
        {
            this.Status = false;
        }
    }
}
