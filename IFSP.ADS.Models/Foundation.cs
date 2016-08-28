﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSP.ADS.Models
{
    public class Foundation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public List<File> Files { get; set; }
    }
}
