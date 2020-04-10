using System;
using System.Collections.Generic;

namespace HumanResourcesMVC.Models
{
    public partial class Request
    {
        public int IdRequest { get; set; }
        public int IdEmployeeSender { get; set; }
        public int IdEmployeeReceiver { get; set; }
        public DateTime Date { get; set; }
        public decimal QuantityRequested { get; set; }
        public int IdRequestType { get; set; }
        public int IdStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CommentManager { get; set; }
        public string CommentEmployee { get; set; }

        public virtual Employee IdEmployeeReceiverNavigation { get; set; }
        public virtual Employee IdEmployeeSenderNavigation { get; set; }
        public virtual RequestType IdRequestTypeNavigation { get; set; }
        public virtual Status IdStatusNavigation { get; set; }
    }
}
