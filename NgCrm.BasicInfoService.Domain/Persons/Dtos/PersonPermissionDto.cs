using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;

namespace NgCrm.BasicInfoService.Domain.Persons.Dtos
{
    public class PersonPermissionDto : Dto
    {
        public long Id { get; set; }
        public long WorkspaceId { get; set; }
        public IEnumerable<PositionPermissionDto> PositionPermissionDtos { get; set; }
        public IEnumerable<PersonPositionPermissionDto> PersonPositionPermissionDtos { get; set; }
    }
}
