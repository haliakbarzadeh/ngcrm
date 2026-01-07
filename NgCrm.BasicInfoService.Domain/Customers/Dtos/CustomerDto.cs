using Goldiran.Framework.Application.Helpers;
using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.BaseInfos.Dtos;
using NgCrm.BasicInfoService.Domain.BaseInfos.ReadModels;
using NgCrm.BasicInfoService.Domain.Common.Enums;
using NgCrm.BasicInfoService.Domain.Customers.Entities;
using NgCrm.BasicInfoService.Domain.Customers.Enums;
using NgCrm.BasicInfoService.Domain.Persons.Enums;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Customers.Dtos
{
    public class CustomerDto : Dto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get{ return CustomerTypeId == CustomerTypes.Real ? $"{FirstName} {LastName}" : CompanyName; } }
        public CustomerTypes CustomerTypeId { get; set; }
        public string CustomerTypeDesc { get { return CustomerTypeId.GetEnumDescription(); } }
        public bool IsIranian { get; set; }
        public string CompanyName { get; set; }
        public string BrandName { get; set; }
        public string NationalCode { get; set; }
        public GenderTypes? GenderTypeId { get; set; }
        public string GenderTypeDesc { get { return GenderTypeId != null? GenderTypeId.GetEnumDescription():string.Empty; } }
        public bool IsActive { get; set; }
        public bool IsVIP { get; set; }
        public long? CustomerTitleId { get; set; }
        public long? NationalityId { get; set; }
        public long? VipReasonId { get; set; }
        public string? CustomerTitle { get; set; }
        public string? Nationality { get; set; }
        public VipReasonTypes? VipReasonTypeId { get; set; }
        public string VipReasonTypeDesc { get { return VipReasonTypeId != null ? VipReasonTypeId.GetEnumDescription() : string.Empty; } }
        public long? IntroPersonId { get; set; }
        public DegreeTypes? DegreeTypeId { get; set; }
        public string DegreeTypeDesc { get { return DegreeTypeId != null ? DegreeTypeId.GetEnumDescription() : string.Empty; } }
        public MarriageTypes? MarriageTypeId { get; set; }
        public string MarriageTypeDesc { get { return MarriageTypeId != null ? MarriageTypeId.GetEnumDescription() : string.Empty; } }
        public DateTime? BirthDate { get; set; }
        public long? BirthPlaceId { get; set; }
        public long? RegisteryPlaceId { get; set; }
        public string IntroPersonTitle { get; set; }
        public virtual ICollection<CustomerAddressDto> CustomerAddresses { get; set; } = new List<CustomerAddressDto>();
        public virtual ICollection<CustomerContactDto> CustomerContacts { get; set; } = new List<CustomerContactDto>();
        public virtual ICollection<CustomerRelationDto> CustomerRelations { get; set; } = new List<CustomerRelationDto>();


    }
}
