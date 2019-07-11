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
    
    public partial class ContractDetailBase
    {
        public ContractDetailBase()
        {
            this.IncidentBases = new HashSet<IncidentBase>();
        }
    
        public System.Guid ContractDetailId { get; set; }
        public Nullable<System.Guid> ServiceAddress { get; set; }
        public Nullable<System.Guid> UoMId { get; set; }
        public Nullable<System.Guid> ProductId { get; set; }
        public string ProductSerialNumber { get; set; }
        public System.Guid ContractId { get; set; }
        public Nullable<int> LineItemOrder { get; set; }
        public Nullable<int> ServiceContractUnitsCode { get; set; }
        public Nullable<int> InitialQuantity { get; set; }
        public string Title { get; set; }
        public string EffectivityCalendar { get; set; }
        public System.DateTime ActiveOn { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public System.DateTime ExpiresOn { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public int TotalAllotments { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public byte[] VersionNumber { get; set; }
        public decimal Price { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Net { get; set; }
        public int StateCode { get; set; }
        public Nullable<int> AllotmentsRemaining { get; set; }
        public Nullable<int> StatusCode { get; set; }
        public Nullable<int> AllotmentsUsed { get; set; }
        public Nullable<System.Guid> UoMScheduleId { get; set; }
        public Nullable<decimal> DiscountPercentage { get; set; }
        public Nullable<int> TimeZoneRuleVersionNumber { get; set; }
        public Nullable<int> ImportSequenceNumber { get; set; }
        public Nullable<System.DateTime> OverriddenCreatedOn { get; set; }
        public Nullable<System.Guid> TransactionCurrencyId { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public Nullable<int> UTCConversionTimeZoneCode { get; set; }
        public Nullable<decimal> Discount_Base { get; set; }
        public Nullable<decimal> Rate_Base { get; set; }
        public Nullable<decimal> Price_Base { get; set; }
        public Nullable<decimal> Net_Base { get; set; }
        public Nullable<int> AllotmentsOverage { get; set; }
        public Nullable<System.Guid> CustomerId { get; set; }
        public Nullable<System.Guid> ModifiedOnBehalfBy { get; set; }
        public Nullable<System.Guid> CreatedOnBehalfBy { get; set; }
        public Nullable<int> CustomerIdType { get; set; }
        public string CustomerIdName { get; set; }
        public string CustomerIdYomiName { get; set; }
        public Nullable<System.Guid> TransferHistoryId { get; set; }
    
        public virtual ContractBase ContractBase { get; set; }
        public virtual ICollection<IncidentBase> IncidentBases { get; set; }
        public virtual UoMScheduleBase UoMScheduleBase { get; set; }
        public virtual CustomerAddressBase CustomerAddressBase { get; set; }
        public virtual TransferHistoryBase TransferHistoryBase { get; set; }
        public virtual ProductBase ProductBase { get; set; }
        public virtual TransactionCurrencyBase TransactionCurrencyBase { get; set; }
        public virtual UoMBase UoMBase { get; set; }
    }
}