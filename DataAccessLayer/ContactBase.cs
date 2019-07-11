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
    
    public partial class ContactBase
    {
        public ContactBase()
        {
            this.AccountBases = new HashSet<AccountBase>();
            this.IncidentBases = new HashSet<IncidentBase>();
            this.IncidentBases1 = new HashSet<IncidentBase>();
            this.EntitlementBases = new HashSet<EntitlementBase>();
            this.ContactBase1 = new HashSet<ContactBase>();
            this.LeadBases = new HashSet<LeadBase>();
            this.OpportunityBases = new HashSet<OpportunityBase>();
        }
    
        public System.Guid ContactId { get; set; }
        public Nullable<System.Guid> DefaultPriceLevelId { get; set; }
        public Nullable<int> CustomerSizeCode { get; set; }
        public Nullable<int> CustomerTypeCode { get; set; }
        public Nullable<int> PreferredContactMethodCode { get; set; }
        public Nullable<int> LeadSourceCode { get; set; }
        public Nullable<System.Guid> OriginatingLeadId { get; set; }
        public Nullable<System.Guid> OwningBusinessUnit { get; set; }
        public Nullable<int> PaymentTermsCode { get; set; }
        public Nullable<int> ShippingMethodCode { get; set; }
        public Nullable<bool> ParticipatesInWorkflow { get; set; }
        public Nullable<bool> IsBackofficeCustomer { get; set; }
        public string Salutation { get; set; }
        public string JobTitle { get; set; }
        public string FirstName { get; set; }
        public string Department { get; set; }
        public string NickName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string YomiFirstName { get; set; }
        public string FullName { get; set; }
        public string YomiMiddleName { get; set; }
        public string YomiLastName { get; set; }
        public Nullable<System.DateTime> Anniversary { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string GovernmentId { get; set; }
        public string YomiFullName { get; set; }
        public string Description { get; set; }
        public string EmployeeId { get; set; }
        public Nullable<int> GenderCode { get; set; }
        public Nullable<decimal> AnnualIncome { get; set; }
        public Nullable<int> HasChildrenCode { get; set; }
        public Nullable<int> EducationCode { get; set; }
        public string WebSiteUrl { get; set; }
        public Nullable<int> FamilyStatusCode { get; set; }
        public string FtpSiteUrl { get; set; }
        public string EMailAddress1 { get; set; }
        public string SpousesName { get; set; }
        public string AssistantName { get; set; }
        public string EMailAddress2 { get; set; }
        public string AssistantPhone { get; set; }
        public string EMailAddress3 { get; set; }
        public Nullable<bool> DoNotPhone { get; set; }
        public string ManagerName { get; set; }
        public string ManagerPhone { get; set; }
        public Nullable<bool> DoNotFax { get; set; }
        public Nullable<bool> DoNotEMail { get; set; }
        public Nullable<bool> DoNotPostalMail { get; set; }
        public Nullable<bool> DoNotBulkEMail { get; set; }
        public Nullable<bool> DoNotBulkPostalMail { get; set; }
        public Nullable<int> AccountRoleCode { get; set; }
        public Nullable<int> TerritoryCode { get; set; }
        public Nullable<bool> IsPrivate { get; set; }
        public Nullable<decimal> CreditLimit { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<bool> CreditOnHold { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<int> NumberOfChildren { get; set; }
        public string ChildrensNames { get; set; }
        public byte[] VersionNumber { get; set; }
        public string MobilePhone { get; set; }
        public string Pager { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }
        public string Fax { get; set; }
        public Nullable<decimal> Aging30 { get; set; }
        public int StateCode { get; set; }
        public Nullable<decimal> Aging60 { get; set; }
        public Nullable<int> StatusCode { get; set; }
        public Nullable<decimal> Aging90 { get; set; }
        public Nullable<System.Guid> PreferredSystemUserId { get; set; }
        public Nullable<System.Guid> PreferredServiceId { get; set; }
        public Nullable<System.Guid> MasterId { get; set; }
        public Nullable<int> PreferredAppointmentDayCode { get; set; }
        public Nullable<int> PreferredAppointmentTimeCode { get; set; }
        public Nullable<bool> DoNotSendMM { get; set; }
        public Nullable<bool> Merged { get; set; }
        public string ExternalUserIdentifier { get; set; }
        public Nullable<System.Guid> SubscriptionId { get; set; }
        public Nullable<System.Guid> PreferredEquipmentId { get; set; }
        public Nullable<System.DateTime> LastUsedInCampaign { get; set; }
        public Nullable<System.Guid> TransactionCurrencyId { get; set; }
        public Nullable<System.DateTime> OverriddenCreatedOn { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public Nullable<int> ImportSequenceNumber { get; set; }
        public Nullable<int> TimeZoneRuleVersionNumber { get; set; }
        public Nullable<int> UTCConversionTimeZoneCode { get; set; }
        public Nullable<decimal> AnnualIncome_Base { get; set; }
        public Nullable<decimal> CreditLimit_Base { get; set; }
        public Nullable<decimal> Aging60_Base { get; set; }
        public Nullable<decimal> Aging90_Base { get; set; }
        public Nullable<decimal> Aging30_Base { get; set; }
        public System.Guid OwnerId { get; set; }
        public Nullable<System.Guid> CreatedOnBehalfBy { get; set; }
        public Nullable<bool> IsAutoCreate { get; set; }
        public Nullable<System.Guid> ModifiedOnBehalfBy { get; set; }
        public Nullable<System.Guid> ParentCustomerId { get; set; }
        public Nullable<int> ParentCustomerIdType { get; set; }
        public string ParentCustomerIdName { get; set; }
        public int OwnerIdType { get; set; }
        public string ParentCustomerIdYomiName { get; set; }
        public Nullable<System.Guid> ProcessId { get; set; }
        public Nullable<System.Guid> EntityImageId { get; set; }
        public Nullable<System.Guid> StageId { get; set; }
        public Nullable<System.Guid> TransferHistoryId { get; set; }
    
        public virtual ICollection<AccountBase> AccountBases { get; set; }
        public virtual BusinessUnitBase BusinessUnitBase { get; set; }
        public virtual ICollection<IncidentBase> IncidentBases { get; set; }
        public virtual ICollection<IncidentBase> IncidentBases1 { get; set; }
        public virtual ICollection<EntitlementBase> EntitlementBases { get; set; }
        public virtual ICollection<ContactBase> ContactBase1 { get; set; }
        public virtual ContactBase ContactBase2 { get; set; }
        public virtual LeadBase LeadBase { get; set; }
        public virtual EquipmentBase EquipmentBase { get; set; }
        public virtual TransferHistoryBase TransferHistoryBase { get; set; }
        public virtual ICollection<LeadBase> LeadBases { get; set; }
        public virtual ICollection<OpportunityBase> OpportunityBases { get; set; }
        public virtual OwnerBase OwnerBase { get; set; }
        public virtual PriceLevelBase PriceLevelBase { get; set; }
        public virtual ServiceBase ServiceBase { get; set; }
        public virtual SystemUserBase SystemUserBase { get; set; }
        public virtual TransactionCurrencyBase TransactionCurrencyBase { get; set; }
    }
}