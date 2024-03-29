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
    
    public partial class ActivityPartyBase
    {
        public System.Guid ActivityId { get; set; }
        public System.Guid ActivityPartyId { get; set; }
        public Nullable<System.Guid> PartyId { get; set; }
        public int PartyObjectTypeCode { get; set; }
        public int ParticipationTypeMask { get; set; }
        public string AddressUsed { get; set; }
        public string PartyIdName { get; set; }
        public Nullable<double> Effort { get; set; }
        public string ExchangeEntryId { get; set; }
        public Nullable<System.Guid> ResourceSpecId { get; set; }
        public byte[] VersionNumber { get; set; }
        public Nullable<bool> DoNotPhone { get; set; }
        public Nullable<System.DateTime> ScheduledEnd { get; set; }
        public Nullable<System.DateTime> ScheduledStart { get; set; }
        public bool IsPartyDeleted { get; set; }
        public Nullable<System.Guid> TransferHistoryId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        public virtual ActivityPointerBase ActivityPointerBase { get; set; }
        public virtual TransferHistoryBase TransferHistoryBase { get; set; }
    }
}
