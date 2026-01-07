using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.BaseInfos.Contracts;
using NgCrm.BasicInfoService.Domain.BaseInfos.Entities;

namespace NgCrm.BasicInfoService.Application.BasicInfos.Commands
{
    public class DeleteBaseInfoCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeleteBaseInfoCommandHandler : IRequestHandler<DeleteBaseInfoCommand, bool>
    {
        private readonly IBaseInfoCommandRepository _BaseInfoCommandRepository;

        public DeleteBaseInfoCommandHandler(IBaseInfoCommandRepository BaseInfoCommandRepository)
        {
            _BaseInfoCommandRepository = BaseInfoCommandRepository;
        }

        public async Task<bool> Handle(DeleteBaseInfoCommand request, CancellationToken cancellationToken)
        {
            var BaseInfo = await _BaseInfoCommandRepository.GetByIdAsync(request.Id);

            _BaseInfoCommandRepository.Delete(BaseInfo);
            var result = await _BaseInfoCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return 1 > 0;
        }
    }
}
