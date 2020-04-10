using System;
using System.Collections.Generic;

namespace HumanResourcesMVC.Models
{
    public partial class AbsenceType
    {
        public AbsenceType()
        {
            AvailableAbsence = new HashSet<AvailableAbsence>();
        }

        public int IdAbsenceType { get; set; }
        public string AbsenceType1 { get; set; }

        public virtual ICollection<AvailableAbsence> AvailableAbsence { get; set; }
    }
}
