using System;
using System.Collections.Generic;

namespace HumanResourcesMVC.Models
{
    public partial class Job
    {
        public Job()
        {
            Employee = new HashSet<Employee>();
        }

        public int IdJob { get; set; }
        public string JobName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
