namespace Models
{
    public class MobileLoginDetails
    {
        public string UserName { get; set; }
        public int UserID { get; set; }
        public string SQLDB { get; set; }
        public string CultureFormat { get; set; }
        public string TimeZone { get; set; }
        public int StationID { get; set; }
        public bool AccessToGuestList { get; set; }
    }
}
