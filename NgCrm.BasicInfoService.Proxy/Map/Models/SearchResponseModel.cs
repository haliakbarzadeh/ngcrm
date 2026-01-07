using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.Proxy.Map.Models
{
    public class SearchResponseModel
    {
        public int Count { get; set; }
        public List<SearchItem> Items { get; set; }
    }


    public class SearchItem
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Region { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Z { get; set; }
    }

}
