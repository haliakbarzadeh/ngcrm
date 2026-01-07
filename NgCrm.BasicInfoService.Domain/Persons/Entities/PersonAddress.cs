using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;

namespace NgCrm.BasicInfoService.Domain.Persons.Entities
{
    [Auditable]
    public class PersonAddress : Entity
    {
        public PersonAddress(
            long personId,
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
            bool isActive)
        {
            PersonId = personId;
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


        public bool Equals(PersonAddress? obj)
        {
            if (obj is not PersonAddress other)
                return false;

            return PersonId == obj.PersonId &&
                Latitude == obj.Latitude &&
                Longitude == obj.Longitude &&
                ProvinceId == obj.ProvinceId &&
                CountyId == obj.CountyId &&
                City == obj.City &&
                District == obj.District &&
                Village == obj.Village &&
                Zone == obj.Zone &&
                Place == obj.Place &&
                Street == obj.Street &&
                Details == obj.Details &&
                PostalCode == obj.PostalCode &&
                IsActive == obj.IsActive;
        }



        public long PersonId { get; private set; }
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
    }
}

