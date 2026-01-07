using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Users.Enums;

namespace NgCrm.BasicInfoService.Domain.Users.Dtos
{
    public class UserBriefDto : Dto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string NationalCode { get; set; }
        public bool? IsADActive { get; set; }
        public AccountTypes AccountTypeId { get;  set; }
        public bool IsActive { get; set; }
        public Guid? ImageId { get; set; }
    }
}
