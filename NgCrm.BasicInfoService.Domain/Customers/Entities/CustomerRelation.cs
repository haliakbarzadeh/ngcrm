using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;

namespace NgCrm.BasicInfoService.Domain.Customers.Entities
{
    [Auditable]
    public class CustomerRelation : Entity
    {
        public long CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NationalCode { get; private set; }
        public string? MobileNumber { get; private set; }
        public string? FixNumber { get; private set; }
        public long RelationTitleId { get; private set; }

        public CustomerRelation(
            long customerId,
            string firstName,
            string lastName,
            string nationalCode,
            string? mobileNumber,
            string? fixNumber,
            long relationTitleId
            )
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
            MobileNumber = mobileNumber;
            FixNumber = fixNumber;
            RelationTitleId = relationTitleId;
        }

        public void Update(
            long customerId,
            string firstName,
            string lastName,
            string nationalCode,
            string? mobileNumber,
            string? fixNumber,
            long relationTitleId,
             bool isDeleted = false
            )
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
            MobileNumber = mobileNumber;
            FixNumber = fixNumber;
            RelationTitleId = relationTitleId;
            IsDeleted = isDeleted;
        }

    }
}

