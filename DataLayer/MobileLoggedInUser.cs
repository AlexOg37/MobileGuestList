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
    
    public partial class MobileLoggedInUser
    {
        public int ID { get; set; }
        public string VerificationCode { get; set; }
        public System.DateTime Expires { get; set; }
        public string UserName { get; set; }
        public int UserID { get; set; }
        public string SQLDB { get; set; }
        public string CultureFormat { get; set; }
        public string TimeZone { get; set; }
        public int StationID { get; set; }
        public string StationCall { get; set; }
        public bool AccessToGuestList { get; set; }
    }
}
