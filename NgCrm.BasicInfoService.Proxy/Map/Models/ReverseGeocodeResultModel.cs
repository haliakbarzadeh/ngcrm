using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.Proxy.Map.Models
{
    public class ReverseGeocodeResultModel
    {
        public string Status { get; set; }
        public string Neighbourhood { get; set; }
        public string Municipality_Zone { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public bool In_Traffic_Zone { get; set; }
        public bool In_Odd_Even_Zone { get; set; }
        public string Route_Name { get; set; }
        public string Route_Type { get; set; }
        public string Place { get; set; }
        public string District { get; set; }
        public string Formatted_Address { get; set; }
        public string Village { get; set; }
        public string County { get; set; }
    }
}
