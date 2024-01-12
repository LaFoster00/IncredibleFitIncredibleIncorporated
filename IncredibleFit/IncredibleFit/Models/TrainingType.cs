﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncredibleFit.SQL;

namespace IncredibleFit.Models
{
    [Entity("TRAINING TYPE")]
    internal class TrainingType
    {
        [Field("id")]
        public int id { get; private set; }
        [Field("name")]
        public string name { get; set; }
    }
}