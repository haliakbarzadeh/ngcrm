using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.Proxy.Map.Models
{
    public class SearchRequestModel:GeocodeRequestModel
    {
        public string Term { get; set; }
    }
}
