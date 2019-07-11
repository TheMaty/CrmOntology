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
    
    public partial class TransactionCurrencyBase
    {
        public TransactionCurrencyBase()
        {
            this.AccountBases = new HashSet<AccountBase>();
            this.ActivityPointerBases = new HashSet<ActivityPointerBase>();
            this.ActivityPointerBases1 = new HashSet<ActivityPointerBase>();
            this.BusinessUnitBases = new HashSet<BusinessUnitBase>();
            this.CampaignBases = new HashSet<CampaignBase>();
            this.CompetitorBases = new HashSet<CompetitorBase>();
            this.ConnectionBases = new HashSet<ConnectionBase>();
            this.ContactBases = new HashSet<ContactBase>();
            this.ContractBases = new HashSet<ContractBase>();
            this.ContractDetailBases = new HashSet<ContractDetailBase>();
            this.CustomerAddressBases = new HashSet<CustomerAddressBase>();
            this.EntitlementBases = new HashSet<EntitlementBase>();
            this.EquipmentBases = new HashSet<EquipmentBase>();
            this.IncidentBases = new HashSet<IncidentBase>();
            this.KbArticleBases = new HashSet<KbArticleBase>();
            this.LeadBases = new HashSet<LeadBase>();
            this.OpportunityBases = new HashSet<OpportunityBase>();
            this.OrganizationBases = new HashSet<OrganizationBase>();
            this.PriceLevelBases = new HashSet<PriceLevelBase>();
            this.ProductBases = new HashSet<ProductBase>();
            this.SocialProfileBases = new HashSet<SocialProfileBase>();
            this.SystemUserBases = new HashSet<SystemUserBase>();
            this.TerritoryBases = new HashSet<TerritoryBase>();
            this.TeamBases = new HashSet<TeamBase>();
        }
    
        public Nullable<int> StatusCode { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public int StateCode { get; set; }
        public byte[] VersionNumber { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<int> ImportSequenceNumber { get; set; }
        public Nullable<System.DateTime> OverriddenCreatedOn { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public System.Guid TransactionCurrencyId { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public string CurrencySymbol { get; set; }
        public Nullable<System.Guid> UniqueDscId { get; set; }
        public string CurrencyName { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public string ISOCurrencyCode { get; set; }
        public System.Guid OrganizationId { get; set; }
        public int CurrencyPrecision { get; set; }
        public Nullable<System.Guid> CreatedOnBehalfBy { get; set; }
        public Nullable<System.Guid> ModifiedOnBehalfBy { get; set; }
        public Nullable<System.Guid> EntityImageId { get; set; }
        public Nullable<System.Guid> TransferHistoryId { get; set; }
    
        public virtual ICollection<AccountBase> AccountBases { get; set; }
        public virtual ICollection<ActivityPointerBase> ActivityPointerBases { get; set; }
        public virtual ICollection<ActivityPointerBase> ActivityPointerBases1 { get; set; }
        public virtual ICollection<BusinessUnitBase> BusinessUnitBases { get; set; }
        public virtual ICollection<CampaignBase> CampaignBases { get; set; }
        public virtual ICollection<CompetitorBase> CompetitorBases { get; set; }
        public virtual ICollection<ConnectionBase> ConnectionBases { get; set; }
        public virtual ICollection<ContactBase> ContactBases { get; set; }
        public virtual ICollection<ContractBase> ContractBases { get; set; }
        public virtual ICollection<ContractDetailBase> ContractDetailBases { get; set; }
        public virtual ICollection<CustomerAddressBase> CustomerAddressBases { get; set; }
        public virtual ICollection<EntitlementBase> EntitlementBases { get; set; }
        public virtual ICollection<EquipmentBase> EquipmentBases { get; set; }
        public virtual ICollection<IncidentBase> IncidentBases { get; set; }
        public virtual ICollection<KbArticleBase> KbArticleBases { get; set; }
        public virtual ICollection<LeadBase> LeadBases { get; set; }
        public virtual ICollection<OpportunityBase> OpportunityBases { get; set; }
        public virtual ICollection<OrganizationBase> OrganizationBases { get; set; }
        public virtual ICollection<PriceLevelBase> PriceLevelBases { get; set; }
        public virtual ICollection<ProductBase> ProductBases { get; set; }
        public virtual ICollection<SocialProfileBase> SocialProfileBases { get; set; }
        public virtual ICollection<SystemUserBase> SystemUserBases { get; set; }
        public virtual ICollection<TerritoryBase> TerritoryBases { get; set; }
        public virtual TransferHistoryBase TransferHistoryBase { get; set; }
        public virtual ICollection<TeamBase> TeamBases { get; set; }
    }
}