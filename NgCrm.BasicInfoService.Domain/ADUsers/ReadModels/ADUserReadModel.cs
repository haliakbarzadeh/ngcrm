using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.ADUsers.ReadModels
{
    public class ADUserReadModel : ReadModel
    {
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public string Position { get; set; }
        public string Groups { get; set; }
        public string Department { get; set; }
        public string TelephoneNumber { get; set; }
        public string UserPrincipalName { get; set; }
    }
}
