using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.BaseInfos.Contracts;
using NgCrm.BasicInfoService.Domain.BaseInfos.Dtos;
using NgCrm.BasicInfoService.Domain.BaseInfos.Entities;
using NgCrm.BasicInfoService.Domain.Common.Enums;

namespace NgCrm.BasicInfoService.Application.BasicInfos.Commands
{
    public class CreateBaseInfoCommand : BaseCommandRequest, IRequest<bool>
    {
        public BaseInfoTypes? BaseInfoTypeId { get; set; }
        public string DisplayValue { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }=true;

    }

    public class CreateBaseInfoCommandHandler : IRequestHandler<CreateBaseInfoCommand, bool>
    {
        private readonly IBaseInfoCommandRepository _BaseInfoCommandRepository;

        public CreateBaseInfoCommandHandler(IBaseInfoCommandRepository BaseInfoCommandRepository)
        {
            _BaseInfoCommandRepository = BaseInfoCommandRepository;
        }

        public async Task<bool> Handle(CreateBaseInfoCommand request, CancellationToken cancellationToken)
        {
            var BaseInfo = new BaseInfo((BaseInfoTypes)request.BaseInfoTypeId, request.DisplayValue,request.Value,request.IsActive);

            _BaseInfoCommandRepository.Add(BaseInfo);

            var result = await _BaseInfoCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
