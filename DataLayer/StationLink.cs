//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class StationLink
    {
        public int StationLinkID { get; set; }
        public string StationCall { get; set; }
        public string StationDB { get; set; }
        public string ClientKey { get; set; }
        public string OfflineStudioBackupTime { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string TimeZoneId { get; set; }
        public Nullable<System.DateTime> ShutOffDate { get; set; }
    }
}