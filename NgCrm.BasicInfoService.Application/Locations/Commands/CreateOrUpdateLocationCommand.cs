using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Locations.Contracts;
using NgCrm.BasicInfoService.Domain.Locations.Entities;
using NgCrm.BasicInfoService.Domain.Locations.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.Application.Locations.Commands
{
    public class CreateOrUpdateLocationCommand : BaseCommandRequest, IRequest<long>
    {
        public LocationTypes LocationTypeId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string PhoneCode { get; set; }
        public int? SortOrder { get; set; }
        public string Geometry { get; set; }
        public long? ParentId { get; set; }

        public long? OriginalId { get; set; }
    }


    public class CreateOrUpdateLocationCommandHandler : IRequestHandler<CreateOrUpdateLocationCommand, long>
    {
        private readonly ILocationCommandRepository _locationCommandRepository;

        public CreateOrUpdateLocationCommandHandler(ILocationCommandRepository locationCommandRepository)
        {
            _locationCommandRepository = locationCommandRepository;
        }

        public async Task<long> Handle(CreateOrUpdateLocationCommand request, CancellationToken cancellationToken)
        {

            var existingLocation = await _locationCommandRepository.GetByAsync(x => x.OriginalId == request.OriginalId);
            long result;
            if (existingLocation == null)
            {
                var location = new Location(
                   request.LocationTypeId,
                    request.ParentId,
                    request.Title,
                    request.Name,
                    request.PhoneCode,
                    request.SortOrder,
                    request.Geometry,
                    request.OriginalId

                );
                var locationAdded  =  _locationCommandRepository.Add(location);
                await _locationCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                result = locationAdded.Id;
            }
            else
            {
               existingLocation.Update(
               request.LocationTypeId,
               request.ParentId,
               request.Title,
               request.Name,
               request.PhoneCode,
               request.SortOrder,
               request.Geometry,
               request.OriginalId
               
            );
                 _locationCommandRepository.Update(existingLocation);
                await _locationCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                result = existingLocation.Id;
            }
             

            return result;
        }
    }

}
