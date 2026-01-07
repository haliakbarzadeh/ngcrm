using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.OrganizationHistories.Entities
{
    public class OrganizationHistory : AggregateRoot
    {
        public OrganizationHistory(string snapshot, DateTime fromDate)
        {
            Snapshot = snapshot;
            FromDate = fromDate;
        }

        public string Snapshot { get; private set; }
        public DateTime FromDate { get; private set; }

    }
}
