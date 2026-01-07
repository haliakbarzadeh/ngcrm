using Goldiran.Framework.Application.Helpers;
using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.Users.Dtos;
using NgCrm.BasicInfoService.Domain.Users.ReadModels;

namespace NgCrm.BasicInfoService.Mapping.Users
{
    public class UserReadModelToUserBriefDtoMapping : MapProfile<UserReadModel, UserBriefDto>
    {
        public UserReadModelToUserBriefDtoMapping()
        {
            ForMember(x => x.FullName, x => x.Person.FirstName + " " + x.Person.LastName);
            ForMember(x => x.ImageId, x => x.Person.ImageId);
            ForMember(x => x.NationalCode, x => x.Person.NationalCode);       
            ForMember(x => x.NationalCode, x => x.Person.NationalCode);       
        }
    }

    public class UserReadModelToUserDtoMapping : MapProfile<UserReadModel, UserDto>
    {
        public UserReadModelToUserDtoMapping()
        {
            ForMember(x => x.AccountTypeTitle, x => x.AccountTypeId.GetEnumDescription());
            ForMember(x => x.Username, x => x.Username ?? x.ADUsername);
        }
    }

}
