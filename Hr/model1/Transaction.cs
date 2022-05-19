using System;
using System.Collections.Generic;

#nullable disable

namespace Hr.model1
{
    public partial class Transaction
    {
        public Guid TransactionId { get; set; }
        public long EmployeeId { get; set; }
        public DateTime DateTime { get; set; }
        public string Type { get; set; }
        public string OrderType { get; set; }
        public string OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public int LocationId { get; set; }
        public bool IsProcessed { get; set; }
        public string Manager { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Ip { get; set; }
        public string Pcname { get; set; }
        public string Notes { get; set; }
        public string TypeUsed { get; set; }
        public Guid? GroupKey { get; set; }
        public bool? IsEnquiryTransaction { get; set; }
        public Guid? GeoLocationId { get; set; }
        public string Picture { get; set; }
        public string AccessType { get; set; }
    }
}
