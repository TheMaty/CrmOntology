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
    
    public partial class SiteBase
    {
        public SiteBase()
        {
            this.ActivityPointerBases = new HashSet<ActivityPointerBase>();
            this.EquipmentBases = new HashSet<EquipmentBase>();
            this.SystemUserBases = new HashSet<SystemUserBase>();
        }
    
        public byte[] VersionNumber { get; set; }
        public System.Guid OrganizationId { get; set; }
        public string EMailAddress { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public System.Guid SiteId { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public int TimeZoneCode { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<int> ImportSequenceNumber { get; set; }
        public Nullable<System.DateTime> OverriddenCreatedOn { get; set; }
        public Nullable<System.Guid> CreatedOnBehalfBy { get; set; }
        public Nullable<System.Guid> ModifiedOnBehalfBy { get; set; }
        public Nullable<System.Guid> TransferHistoryId { get; set; }
    
        public virtual ICollection<ActivityPointerBase> ActivityPointerBases { get; set; }
        public virtual ICollection<EquipmentBase> EquipmentBases { get; set; }
        public virtual TransferHistoryBase TransferHistoryBase { get; set; }
        public virtual ICollection<SystemUserBase> SystemUserBases { get; set; }
    }
}
