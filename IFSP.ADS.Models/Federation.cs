﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ADS.Models
{
    public class Federation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get;set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }

        public bool Status { get; set; } = true;

        public void Delete()
        {
            this.Status = false;
        }
    }
}
