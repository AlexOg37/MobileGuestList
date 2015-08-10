using System;
namespace Models
{
    public class Guest
    {
        public int ContWinID { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string HomeCity { get; set; }
        public string BusinessCity { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string BusinessPhone { get; set; }
        public DateTime? FulfillmentDate { get; set; }
        public bool? Attended { get; set; }
    }
}
