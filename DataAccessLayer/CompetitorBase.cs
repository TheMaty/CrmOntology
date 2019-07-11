//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRMOntology.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class CompetitorBase
    {
        public CompetitorBase()
        {
            this.ActivityPointerBases = new HashSet<ActivityPointerBase>();
            this.CompetitorProducts = new HashSet<CompetitorProduct>();
        }
    
        public System.Guid CompetitorId { get; set; }
        public System.Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public string ReferenceInfoUrl { get; set; }
        public Nullable<decimal> ReportedRevenue { get; set; }
        public Nullable<int> ReportingQuarter { get; set; }
        public Nullable<int> ReportingYear { get; set; }
        public string Strengths { get; set; }
        public string Weaknesses { get; set; }
        public string Opportunities { get; set; }
        public string Threats { get; set; }
        public string TickerSymbol { get; set; }
        public string KeyProduct { get; set; }
        public string StockExchange { get; set; }
        public Nullable<double> WinPercentage { get; set; }
        public string WebSiteUrl { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public byte[] VersionNumber { get; set; }
        public Nullable<int> UTCConversionTimeZoneCode { get; set; }
        public Nullable<int> TimeZoneRuleVersionNumber { get; set; }
        public Nullable<System.DateTime> OverriddenCreatedOn { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public Nullable<System.Guid> TransactionCurrencyId { get; set; }
        public Nullable<int> ImportSequenceNumber { get; set; }
        public Nullable<decimal> ReportedRevenue_Base { get; set; }
        public string YomiName { get; set; }
        public Nullable<System.Guid> ModifiedOnBehalfBy { get; set; }
        public Nullable<System.Guid> CreatedOnBehalfBy { get; set; }
        public Nullable<System.Guid> EntityImageId { get; set; }
        public Nullable<System.Guid> ProcessId { get; set; }
        public Nullable<System.Guid> StageId { get; set; }
        public Nullable<System.Guid> TransferHistoryId { get; set; }
    
        public virtual ICollection<ActivityPointerBase> ActivityPointerBases { get; set; }
        public virtual ICollection<CompetitorProduct> CompetitorProducts { get; set; }
        public virtual TransferHistoryBase TransferHistoryBase { get; set; }
        public virtual TransactionCurrencyBase TransactionCurrencyBase { get; set; }
    }
}
