using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.Proxy.Map.Models
{
    public class ReverseGeocodeResponseApiModel
    {
        public string Status { get; set; }
        public string Neighbourhood { get; set; }
        public string MunicipalityZone { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public bool InTrafficZone { get; set; }
        public bool InOddEvenZone { get; set; }
        public string RouteName { get; set; }
        public string RouteType { get; set; }
        public string Place { get; set; }
        public string District { get; set; }
        public string FormattedAddress { get; set; }
        public string Village { get; set; }
        public string County { get; set; }
    }
}
