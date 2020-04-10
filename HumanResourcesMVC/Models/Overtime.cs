﻿using System;
using System.Collections.Generic;

namespace HumanResourcesMVC.Models
{
    public partial class Overtime
    {
        public int IdOvertime { get; set; }
        public DateTime ToBeSettledBefore { get; set; }
        public int Hours { get; set; }
        public int IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
