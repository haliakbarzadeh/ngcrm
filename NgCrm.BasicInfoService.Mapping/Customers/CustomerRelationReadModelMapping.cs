using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;
using NgCrm.BasicInfoService.Domain.Customers.ReadModels;

namespace NgCrm.BasicInfoService.Mapping.Customers
{
    public class CustomerRelationReadModelMapping : MapProfile<CustomerRelationReadModel, CustomerRelationDto>
    {
        public CustomerRelationReadModelMapping()
        {
            ForMember(x => x.RelationTitle, x => x.RelationTitle.DisplayValue);
        }
    }
}
