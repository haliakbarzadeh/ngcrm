using Goldiran.Framework.Application.Commands;
using Goldiran.Framework.Domain.Exceptions;
using Goldiran.Framework.Domain.Services;
using MediatR;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.ReadModels;
using NgCrm.BasicInfoService.Domain.Users.Contracts;
using NgCrm.BasicInfoService.Domain.Users.Dtos;
using NgCrm.BasicInfoService.Domain.Users.ReadModels;
using NgCrm.BasicInfoService.Domain.Users.Services;
using System.Security.Claims;

namespace NgCrm.BasicInfoService.Application.Users.Commands
{
    public class SelectPositionCommand : BaseCommandRequest, IRequest<LoginResultDto>
    {
        public long PositionId { get; set; }
    }

    public class SelectPositionCommandHandler : IRequestHandler<SelectPositionCommand, LoginResultDto>
    {
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly ITokenService _tokenService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IPositionQueryRepository _positionQueryRepository;

        public SelectPositionCommandHandler(
            ITokenService tokenService,
            IUserQueryRepository userQueryRepository,
            ICurrentUserService currentUserService,
            IPositionQueryRepository positionQueryRepository)
        {
            _tokenService = tokenService;
            _userQueryRepository = userQueryRepository;
            _currentUserService = currentUserService;
            _positionQueryRepository = positionQueryRepository;
        }

        public async Task<LoginResultDto> Handle(SelectPositionCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetByIdAsync((long)_currentUserService.UserId, cancellationToken);
            var position = await _positionQueryRepository.GetByIdAsync(request.PositionId, cancellationToken, e => e.Organization);

            ValidateUserAsync(user, position);

            var claims = CreateUserClaims(user, position);
            var result = CreateLoginResult(user, claims);

            return result;
        }

        private void ValidateUserAsync(UserReadModel user, PositionReadModel position)
        {
            if (user is null)
            {
                throw new ValidationException("نام کاربری یا رمز عبور نادرست است");
            }

            if (position is null)
            {
                throw new ValidationException("سمت یافت نشد");
            }

            if (!position.IsActive)
            {
                throw new ValidationException("سمت فعال وجود ندارد");
            }
        }

        private List<Claim> CreateUserClaims(UserReadModel user, PositionReadModel position)
        {
            var claims = new List<Claim>
            {
                new("userId", user.Id.ToString()),
                new("firstName", user.Person.FirstName),
                new("lastName", user.Person.LastName),
                new("userName", user.Username),
                new("positionId", position.Id.ToString()),
                new("positionTitle", position.Title),
                new("organizationId", position.Organization.Id.ToString()),
                new("organizationName", position.Organization.Title)
            };

            return claims;
        }

        private LoginResultDto CreateLoginResult(UserReadModel user, List<Claim> claims)
        {
            var token = _tokenService.CreateToken(user.Username, claims);

            return new LoginResultDto
            {
                IsAuthenticated = true,
                Username = user.Username,
                Token = token,
                LoginType = Domain.Users.Enums.LoginTypes.ActiveDirectory,
                HasSinglePosition = false               
            };
        }
    }
}
