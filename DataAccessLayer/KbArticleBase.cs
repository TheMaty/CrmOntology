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
    
    public partial class KbArticleBase
    {
        public KbArticleBase()
        {
            this.IncidentBases = new HashSet<IncidentBase>();
        }
    
        public System.Guid KbArticleId { get; set; }
        public System.Guid KbArticleTemplateId { get; set; }
        public System.Guid OrganizationId { get; set; }
        public System.Guid SubjectId { get; set; }
        public string ArticleXml { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public int StateCode { get; set; }
        public Nullable<int> StatusCode { get; set; }
        public byte[] VersionNumber { get; set; }
        public string KeyWords { get; set; }
        public Nullable<int> ImportSequenceNumber { get; set; }
        public Nullable<System.DateTime> OverriddenCreatedOn { get; set; }
        public Nullable<System.Guid> CreatedOnBehalfBy { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public Nullable<System.Guid> ModifiedOnBehalfBy { get; set; }
        public Nullable<System.Guid> TransactionCurrencyId { get; set; }
        public Nullable<int> LanguageCode { get; set; }
        public Nullable<System.Guid> EntityImageId { get; set; }
        public Nullable<System.Guid> TransferHistoryId { get; set; }
    
        public virtual ICollection<IncidentBase> IncidentBases { get; set; }
        public virtual TransferHistoryBase TransferHistoryBase { get; set; }
        public virtual SubjectBase SubjectBase { get; set; }
        public virtual TransactionCurrencyBase TransactionCurrencyBase { get; set; }
    }
}