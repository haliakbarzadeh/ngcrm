using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.OrganizationHistories.ReadModels
{
    public class OrganizationHistoryReadModel : ReadModel
    {
        public string Snapshot { get; set; }
        public DateTime FromDate { get; set; }
    }
}
