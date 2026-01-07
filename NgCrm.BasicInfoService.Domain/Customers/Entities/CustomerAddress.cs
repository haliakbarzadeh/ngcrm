using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;

namespace NgCrm.BasicInfoService.Domain.Customers.Entities
{
    [Auditable]
    public class CustomerAddress : Entity
    {
        public long CustomerId { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public long ProvinceId { get; private set; }
        public long CountyId { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }
        public string Village { get; private set; }
        public int? Zone { get; private set; }
        public string Place { get; private set; }
        public string Street { get; private set; }
        public string Details { get; private set; }
        public string PostalCode { get; private set; }
        public bool IsActive { get; private set; }

        public CustomerAddress(
            long customerId,
            string latitude,
            string longitude,
            long provinceId,
            long countyId,
            string city,
            string district,
            string village,
            int? zone,
            string place,
            string street,
            string details,
            string postalCode,
            bool isActive
            )
        {
            CustomerId = customerId;
            Latitude = latitude;
            Longitude = longitude;
            ProvinceId = provinceId;
            CountyId = countyId;
            City = city;
            District = district;
            Village = village;
            Zone = zone;
            Place = place;
            Street = street;
            Details = details;
            PostalCode = postalCode;
            IsActive = isActive;

        }

        public void Update(
            long customerId,
            string latitude,
            string longitude,
            long provinceId,
            long countyId,
            string city,
            string district,
            string village,
            int? zone,
            string place,
            string street,
            string details,
            string postalCode,
            bool isActive,
            bool isDeleted = false
            )
        {
            CustomerId = customerId;
            Latitude = latitude;
            Longitude = longitude;
            ProvinceId = provinceId;
            CountyId = countyId;
            City = city;
            District = district;
            Village = village;
            Zone = zone;
            Place = place;
            Street = street;
            Details = details;
            PostalCode = postalCode;
            IsActive = isActive;
            IsDeleted = isDeleted;
        }



    }
}

