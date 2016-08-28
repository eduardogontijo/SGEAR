﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ADS.Models
{
    public class Field
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
    }
}
