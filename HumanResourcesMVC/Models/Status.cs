using System;
using System.Collections.Generic;

namespace HumanResourcesMVC.Models
{
    public partial class Status
    {
        public Status()
        {
            Request = new HashSet<Request>();
        }

        public int IdStatus { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Request> Request { get; set; }
    }
}
