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
    
    public partial class PhoneCallBase
    {
        public System.Guid ActivityId { get; set; }
        public Nullable<System.Guid> TransferHistoryId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        public virtual ActivityPointerBase ActivityPointerBase { get; set; }
        public virtual TransferHistoryBase TransferHistoryBase { get; set; }
    }
}
