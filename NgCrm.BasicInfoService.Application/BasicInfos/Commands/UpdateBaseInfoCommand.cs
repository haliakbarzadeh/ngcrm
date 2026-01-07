using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Permissions.Entities;
using NgCrm.BasicInfoService.Domain.BaseInfos.Contracts;
using NgCrm.BasicInfoService.Domain.BaseInfos.Dtos;
using NgCrm.BasicInfoService.Domain.BaseInfos.Entities;
using NgCrm.BasicInfoService.Domain.Common.Enums;

namespace NgCrm.BasicInfoService.Application.BasicInfos.Commands
{
    public class UpdateBaseInfoCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
        public BaseInfoTypes? BaseInfoTypeId { get; set; }
        public string DisplayValue { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; } = true;

    }

    public class UpdateBaseInfoCommandHandler : IRequestHandler<UpdateBaseInfoCommand, bool>
    {
        private readonly IBaseInfoCommandRepository _BaseInfoCommandRepository;

        public UpdateBaseInfoCommandHandler(IBaseInfoCommandRepository BaseInfoCommandRepository)
        {
            _BaseInfoCommandRepository = BaseInfoCommandRepository;
        }

        public async Task<bool> Handle(UpdateBaseInfoCommand request, CancellationToken cancellationToken)
        {
            var BaseInfo = await _BaseInfoCommandRepository.GetByIdAsync(request.Id);

            BaseInfo.Update((BaseInfoTypes)request.BaseInfoTypeId, request.DisplayValue, request.Value, request.IsActive);

            _BaseInfoCommandRepository.Update(BaseInfo);      
            
            var result = await _BaseInfoCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
