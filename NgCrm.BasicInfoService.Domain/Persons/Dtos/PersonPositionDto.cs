using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;

namespace NgCrm.BasicInfoService.Domain.Persons.Dtos
{
    public class PersonPositionDto : Dto
    {
        public long Id { get; set; }
        public long PositionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string InternalNumber { get; set; }
        public bool IsActive { get; set; }
        public PositionDto PositionDto { get; set; }
    }
}
