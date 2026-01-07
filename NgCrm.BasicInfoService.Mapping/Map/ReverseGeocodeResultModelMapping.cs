using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.Organizations.Dtos;
using NgCrm.BasicInfoService.Domain.Organizations.ReadModels;
using NgCrm.BasicInfoService.Proxy.Map.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.Mapping.Map
{
    
    public class ReverseGeocodeResultModelMapping : MapProfile<ReverseGeocodeResultModel, ReverseGeocodeResponseApiModel>
    {
        public ReverseGeocodeResultModelMapping()
        {
            ForMember(x=>x.MunicipalityZone, x => x.Municipality_Zone);
            ForMember(x => x.InTrafficZone, x => x.In_Traffic_Zone);
            ForMember(x => x.InOddEvenZone, x => x.In_Odd_Even_Zone);
            ForMember(x => x.RouteName, x => x.Route_Name);
            ForMember(x => x.RouteType, x => x.Route_Type);
            ForMember(x => x.FormattedAddress, x => x.Formatted_Address);

        }
        
    }
}
