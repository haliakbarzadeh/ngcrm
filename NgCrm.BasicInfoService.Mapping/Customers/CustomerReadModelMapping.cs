using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;
using NgCrm.BasicInfoService.Domain.Customers.ReadModels;

namespace NgCrm.BasicInfoService.Mapping.Customers
{
    public class CustomerReadModelMapping : MapProfile<CustomerReadModel, CustomerDto>
    {
        public CustomerReadModelMapping()
        {
            ForMember(x => x.CustomerAddresses, x => x.CustomerAddresses.Where(c => c.IsDeleted == null || c.IsDeleted == false));
            ForMember(x => x.CustomerContacts, x => x.CustomerContacts.Where(c => c.IsDeleted == null || c.IsDeleted == false));
            ForMember(x => x.CustomerRelations, x => x.CustomerRelations.Where(c => c.IsDeleted == null || c.IsDeleted == false));
            ForMember(x => x.CustomerTitle, x => x.CustomerTitleId != null ? x.CustomerTitle.DisplayValue : string.Empty);
            ForMember(x => x.Nationality, x => x.NationalityId != null ? x.Nationality.DisplayValue : string.Empty);
            ForMember(x => x.IntroPersonTitle, x => x.IntroPerson != null ? $"{x.IntroPerson.FirstName} {x.IntroPerson.LastName}" : string.Empty);


        }
    }
}
