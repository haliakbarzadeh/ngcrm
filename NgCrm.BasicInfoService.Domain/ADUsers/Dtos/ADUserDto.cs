using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.ADUsers.Dtos
{
    public class ADUserDto : Dto
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public Guid? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public bool? Active { get; set; }
        public DateTime? PasswordLastSet { get; set; }
        public DateTime? LastLogonDate { get; set; }
        public DateTime? AccountExpireAt { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }
        public string Office { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public long? PersonId { get; set; }
    }
}
