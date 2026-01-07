using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Dtos;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Users.Enums;

namespace NgCrm.BasicInfoService.Domain.Users.Dtos
{
    public class UserDto : Dto
    {
        public long Id { get; set; }

        public SelectItemDto ADUser {  get; set; }
        public PersonSummaryDto personSummaryDto { get; set; }

        public string Username { get; set; }
        public AccountTypes AccountTypeId { get; set; }
        public string AccountTypeTitle { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public IEnumerable<SelectItemDto> AccessGroups { get; set; }
    }
}
