﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebModeling.Models
{
    public class Simulation
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public DateTime CreateDatetime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}