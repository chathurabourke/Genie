﻿using Genie.Models.Abstract;

namespace Genie.Models
{
    public class StoredProcedure : IStoredProcedure
    {
        public string Name { get; set; }
        public string PassString { get; set; }
        public string ParamString { get; set; }
    }
}
