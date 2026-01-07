using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;
using NgCrm.BasicInfoService.Domain.Users.Enums;

namespace NgCrm.BasicInfoService.Domain.Users.Entities;

[Auditable]
public class User : AggregateRoot
{
    public User(long personId,
        string username,
        string description,
        string password,
        bool isActive)
    {
        PersonId = personId;
        Username = username;
        Description = description;
        Password = password;
        IsActive = isActive;

        AccountTypeId = AccountTypes.Local;
    }

    public void SetADUser(string adUsername, long adUserId, bool? isADActive)
    {
        ADUsername = adUsername;
        ADUserId = adUserId;
        IsADActive = isADActive;
        Username = adUsername;
        Password = null;
        AccountTypeId = AccountTypes.ActiveDirectory;
    }

    public void Update(long personId,
       string username,
       string description,
       string password,
       AccountTypes accountTypeId,
       string adUsername, 
       long? adUserId,
       bool? isADActive)
    {
        PersonId = personId;
        Username = username;
        Description = description;
        Password = password;

        ADUsername = adUsername;
        ADUserId = adUserId;
        IsADActive = isADActive;

        AccountTypeId = accountTypeId;
    }

    public long PersonId { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public AccountTypes AccountTypeId { get; private set; }
    public bool IsActive { get; private set; }
    public string ADUsername { get; private set; }
    public long? ADUserId { get; private set; }
    public bool? IsADActive { get; private set; }
    public string Description { get; private set; }
}
