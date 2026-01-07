using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;
using NgCrm.BasicInfoService.Domain.Users.Enums;

namespace NgCrm.BasicInfoService.Domain.Users.ReadModels
{
    public class UserReadModel : ReadModel
    {
        public long PersonId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public AccountTypes AccountTypeId { get; set; }
        public bool IsActive { get; set; }
        public string ADUsername { get; set; }       
        public long? ADUserId { get; set; }
        public bool? IsADActive { get; set; }
        public string Description { get; set; }


        public virtual PersonReadModel Person { get; set; }
    }
}
