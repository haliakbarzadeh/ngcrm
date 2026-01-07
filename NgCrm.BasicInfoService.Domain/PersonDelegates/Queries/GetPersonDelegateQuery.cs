using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Models;
using MediatR;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Dtos;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Enums;

namespace NgCrm.BasicInfoService.Domain.PersonDelegates.Queries
{
    public class GetPersonDelegateQuery : BaseQueryRequest, IRequest<Paged<PersonDelegateBriefDto>>
    {
        public string SearchTerm { get; set; }
        public long? PositionId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DelegateReasonTypes? ReasonTypeId { get; set; }
    }


}