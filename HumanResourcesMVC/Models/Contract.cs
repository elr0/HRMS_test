using System;
using System.Collections.Generic;

namespace HumanResourcesMVC.Models
{
    public partial class Contract
    {
        public Contract()
        {
            ContractBenefit = new HashSet<ContractBenefit>();
        }

        public int IdContract { get; set; }
        public int ContractNumber { get; set; }
        public decimal Salary { get; set; }
        public DateTime ContractStart { get; set; }
        public DateTime ContractEnd { get; set; }
        public string Status { get; set; }
        public int IdContractType { get; set; }
        public int IdEmployee { get; set; }

        public virtual ContractType IdContractTypeNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual ICollection<ContractBenefit> ContractBenefit { get; set; }
    }
}
