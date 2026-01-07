namespace NgCrm.BasicInfoService.Proxy.AD.Models
{
    public class ADUserModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public string TelephoneNumber { get; set; }
        public string UserPrincipalName { get; set; }
        public string Groups { get; set; }
        public bool IsCsUser { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
    }
}
