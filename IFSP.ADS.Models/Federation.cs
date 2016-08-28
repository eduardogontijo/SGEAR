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
        public FederationType Type { get; set; }
        public List<Contact> Contact { get; set; }
        public Address Address { get; set; }
    }
}
