using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.ADUsers.Entities
{
    public class ADUser : AggregateRoot
    {
        public ADUser(Guid? userId, string userName, string firstName, string lastName, string displayName, string email, bool? isActive, string position, string groups, string department, string telephoneNumber, string userPrincipalName)
        {
            UserId = userId;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DisplayName = displayName;
            Email = email;
            IsActive = isActive;
            Position = position;
            Groups = groups;
            Department = department;
            TelephoneNumber = telephoneNumber;
            UserPrincipalName = userPrincipalName;
        }

        public void Update(string userName, string firstName, string lastName, string displayName, string email, bool? isActive, string position, string groups, string department, string telephoneNumber, string userPrincipalName)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DisplayName = displayName;
            Email = email;
            IsActive = isActive;
            Position = position;
            Groups = groups;
            Department = department;
            TelephoneNumber = telephoneNumber;
            UserPrincipalName = userPrincipalName;

            ModifiedAt = DateTime.Now;
        }

        public Guid? UserId { get; private set; }
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string DisplayName { get; private set; }
        public string Email { get; private set; }
        public bool? IsActive { get; private set; }
        public string Position { get; private set; }
        public string Groups { get; private set; }
        public string Department { get; private set; }
        public string TelephoneNumber { get; private set; }
        public string UserPrincipalName { get; private set; }
    }
}
