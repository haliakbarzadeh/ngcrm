using Goldiran.Framework.Application.Commands;
using Goldiran.Framework.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Options;
using NgCrm.BasicInfoService.Domain.ADUsers.Services;
using NgCrm.BasicInfoService.Domain.Common.Models;
using NgCrm.BasicInfoService.Domain.Users.Contracts;
using NgCrm.BasicInfoService.Domain.Users.Dtos;
using NgCrm.BasicInfoService.Domain.Users.ReadModels;
using NgCrm.BasicInfoService.Domain.Users.Services;
using System.Security.Claims;

namespace NgCrm.BasicInfoService.Application.Users.Commands
{
    public class LoginCommand : BaseCommandRequest, IRequest<LoginResultDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResultDto>
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IADMembershipService _adMembershipService;
        private readonly AppSetting _appSetting;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(IUserCommandRepository userCommandRepository, IADMembershipService adMembershipService, IOptions<AppSetting> options, ITokenService tokenService, IUserQueryRepository userQueryRepository)
        {
            _userCommandRepository = userCommandRepository;
            _adMembershipService = adMembershipService;
            _appSetting = options.Value;
            _tokenService = tokenService;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<LoginResultDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetByUserNameAsync(request.Username, cancellationToken);

            ValidateUser(user, request, cancellationToken);

            var claims = CreateUserClaims(user);
            var result = CreateLoginResult(user, claims);

            return result;
        }

        private void ValidateUser(UserReadModel user, LoginCommand request, CancellationToken cancellationToken)
        {
            if (user == null)
            {
                throw new ValidationException("نام کاربری یا رمز عبور نادرست است");
            }

            var authenticationResult = _adMembershipService.Authenticate(request.Username, request.Password);
            if (authenticationResult?.IsAuthenticated != true)
            {
                throw new ValidationException("نام کاربری یا رمز عبور نادرست است");
            }

            if (user.Person.IsActive != true)
            {
                throw new ValidationException("شخص غیرفعال است");
            }

            if (!user.Person.PersonPositions.Any())
            {
                throw new ValidationException("سمت فعال وجود ندارد");
            }
        }

        private List<Claim> CreateUserClaims(UserReadModel user)
        {
            var claims = new List<Claim>
            {
                new("userId", user.Id.ToString()),
                new("personId", user.PersonId.ToString()),
                new("firstName", user.Person.FirstName),
                new("lastName", user.Person.LastName),
                new("userName", user.Username)
            };

            if (user.Person.PersonPositions.Count == 1)
            {
                var position = user.Person.PersonPositions.Single().Position;
                claims.AddRange(new[]
                {
                    new Claim("positionId", position.Id.ToString()),
                    new Claim("positionTitle", position.Title),
                    new Claim("organizationId", position.Organization.Id.ToString()),
                    new Claim("organizationName", position.Organization.Title)
                });
            }

            return claims;
        }

        private LoginResultDto CreateLoginResult(UserReadModel user, List<Claim> claims)
        {
            var token = _tokenService.CreateToken(user.Username, claims);
            var hasSinglePosition = user.Person.PersonPositions.Count == 1;

            return new LoginResultDto
            {
                IsAuthenticated = true,
                Username = user.Username,
                Token = token,
                LoginType = Domain.Users.Enums.LoginTypes.ActiveDirectory,
                HasSinglePosition = hasSinglePosition
            };
        }
    }
}
