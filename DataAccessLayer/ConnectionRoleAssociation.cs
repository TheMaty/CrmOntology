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
    
    public partial class ConnectionRoleAssociation
    {
        public System.Guid AssociatedConnectionRoleId { get; set; }
        public System.Guid ConnectionRoleAssociationId { get; set; }
        public System.Guid ConnectionRoleId { get; set; }
        public byte[] VersionNumber { get; set; }
        public Nullable<System.Guid> TransferHistoryId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        public virtual ConnectionRoleBaseId ConnectionRoleBaseId { get; set; }
        public virtual TransferHistoryBase TransferHistoryBase { get; set; }
    }
}