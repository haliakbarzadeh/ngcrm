using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.Persons.Dtos
{
    public class PersonBriefDto : Dto
    {
        public string FullName { get; set; }
        public long Id { get; set; }
        public string FatherName { get; set; }
        public bool IsLegal { get; set; }
        public string NationalCode { get; set; }
        //public GenderTypes? GenderTypeId { get; set; }
        //public string GenderTypeTitle { get; set; }
        //public MarriageTypes? MarriageTypeId { get; set; }
        //public string MarriageTypeTitle { get; set; }
        //public DateTime? BirthDate { get; set; }
        //public string BirthPlace { get; set; }
        public string PersonalCode { get; set; }
        //public GenderTypes? DegreeTypeId { get; set; }
        //public string DegreeTypeTitle { get; set; }
        //public string Major { get; set; }
        public bool? IsActive { get; set; }
        //public Guid? ImageId { get; set; }
    }
}
