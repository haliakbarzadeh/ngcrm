using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.ADUsers.Dtos
{
    public class ADUserBriefDto : Dto
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public bool? Active { get; set; }
        public string Department { get; set; }
        public long PersonId { get; set; }

    }
}
