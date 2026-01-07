using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.Customers.Dtos
{
    public class CustomerAddressDto : Dto
    {
        public long Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public long ProvinceId { get; set; }
        public long CountyId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Village { get; set; }
        public int? Zone { get; set; }
        public string Place { get; set; }
        public string Street { get; set; }
        public string Details { get; set; }
        public string PostalCode { get; set; }
        public bool IsActive { get; set; }

    }
}
