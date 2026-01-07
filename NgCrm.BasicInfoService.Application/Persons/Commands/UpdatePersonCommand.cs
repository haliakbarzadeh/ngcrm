using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Persons.Entities;
using NgCrm.BasicInfoService.Domain.Persons.Enums;

namespace NgCrm.BasicInfoService.Application.Persons.Commands
{
    public class UpdatePersonCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string CompanyName { get; set; }
        public bool IsLegal { get; set; }
        public string NationalCode { get; set; }
        public GenderTypes? GenderTypeId { get; set; }
        public MarriageTypes? MarriageTypeId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string PersonalCode { get; set; }
        public GenderTypes? DegreeTypeId { get; set; }
        public string Major { get; set; }
        public bool? IsActive { get; set; }
        public Guid? ImageId { get; set; }
        public int? RegistrationNumber { get; set; }
        public string ContactName { get; set; }
        public ContractTypes? ContractTypeId { get; set; }
        public DateTime? StartDate { get; set; }

        public IEnumerable<PersonAddressDto> PersonAddresses { get; set; } = Enumerable.Empty<PersonAddressDto>();
        public IEnumerable<PersonContactDto> PersonContacts { get; set; } = Enumerable.Empty<PersonContactDto>();
        public IEnumerable<PersonPositionDto> PersonPositios { get; set; } = Enumerable.Empty<PersonPositionDto>();
    }

    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        private readonly IPersonCommandRepository _personCommandRepository;

        public UpdatePersonCommandHandler(IPersonCommandRepository personCommandRepository)
        {
            _personCommandRepository = personCommandRepository;
        }

        public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _personCommandRepository.GetByIdAsync(request.Id, e => e.PersonAddresses, e => e.PersonContacts, e => e.PersonPositions);

            person.Update(request.FirstName, request.LastName, request.FatherName, request.CompanyName, request.IsLegal,
                request.NationalCode, request.GenderTypeId, request.MarriageTypeId, request.BirthDate, request.BirthPlace,
                request.PersonalCode, request.DegreeTypeId, request.Major, request.IsActive, request.ImageId, request.ContactName,
                request.RegistrationNumber, request.ContractTypeId, request.StartDate);

            person.SetPersonAddresses(request.PersonAddresses.Select(e => new PersonAddress(person.Id, e.Latitude, e.Longitude, e.ProvinceId, e.CountyId, e.City, e.District, e.Village, e.Zone, e.Place, e.Street, e.Details, e.PostalCode, e.IsActive)));
            person.SetPersonContacts(request.PersonContacts.Select(e => new PersonContact(person.Id, e.ContactTypeId, e.Contact, e.IsActive, e.PriorityOrder)));
            person.SetPersonPosition(request.PersonPositios.Select(e => new PersonPosition(person.Id, e.PositionId, e.StartDate, e.EndDate,e.InternalNumber, e.IsActive)));

            _personCommandRepository.Update(person);

            var result = await _personCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
