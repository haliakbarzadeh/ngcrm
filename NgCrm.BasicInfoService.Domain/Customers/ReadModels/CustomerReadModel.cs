using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.BaseInfos.ReadModels;
using NgCrm.BasicInfoService.Domain.Common.Attributes;
using NgCrm.BasicInfoService.Domain.Customers.Entities;
using NgCrm.BasicInfoService.Domain.Customers.Enums;
using NgCrm.BasicInfoService.Domain.Persons.Enums;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Customers.ReadModels
{
    public class CustomerReadModel : ReadModel
    {
        public CustomerReadModel()
        {
        }
        [DtoAttributes("نام", true)]
        public string FirstName { get; set; }
        [DtoAttributes("نام خانوادگی", true)]
        public string LastName { get; set; }
        [DtoAttributes("نوع مشتری", true)]
        public CustomerTypes CustomerTypeId { get; set; }
        [DtoAttributes("ایرانی بودن", true)]
        public bool IsIranian { get; set; }
        [DtoAttributes("نام شرکت", true)]
        public string CompanyName { get; set; }
        [DtoAttributes("برند شرکت", true)]
        public string BrandName { get; set; }
        [DtoAttributes("کد ملی", true)]
        public string NationalCode { get; set; }
        public GenderTypes? GenderTypeId { get; set; }
        public bool IsActive { get; set; }
        public bool IsVIP { get; set; }
        public VipReasonTypes? VipReasonTypeId { get; set; }
        public long? CustomerTitleId { get; set; }
        public long? NationalityId { get; set; }
        public BaseInfoReadModel? CustomerTitle { get; set; }
        public BaseInfoReadModel? Nationality { get; set; }
        public long? IntroPersonId { get; set; }
        public DegreeTypes? DegreeTypeId { get; set; }
        public MarriageTypes? MarriageTypeId { get; set; }
        public DateTime? BirthDate { get; set; }
        public long? BirthPlaceId { get; set; }
        public long? RegisteryPlaceId { get; set; }
        public PersonReadModel? IntroPerson { get; set; }

        public virtual ICollection<CustomerAddressReadModel> CustomerAddresses { get; set; } = new List<CustomerAddressReadModel>();
        public virtual ICollection<CustomerContactReadModel> CustomerContacts { get; set; } = new List<CustomerContactReadModel>();
        public virtual ICollection<CustomerRelationReadModel> CustomerRelations { get; set; } = new List<CustomerRelationReadModel>();


    }
}