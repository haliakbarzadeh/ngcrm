using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Locations.Entities;
using NgCrm.BasicInfoService.Domain.Locations.ReadModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace NgCrm.BasicInfoService.Domain.Customers.ReadModels
{
    public class CustomerAddressReadModel : ReadModel
    {
        public long CustomerId { get; set; }
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
        public LocationReadModel Province { get; set; }
        public LocationReadModel County { get; set; }
        public CustomerReadModel Customer { get; set; }
    }
}

