using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.Proxy.Map.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Geometry { get; set; }
    }
}
