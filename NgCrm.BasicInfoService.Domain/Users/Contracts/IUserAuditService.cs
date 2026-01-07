namespace NgCrm.BasicInfoService.Domain.Users.Contracts
{
    public interface IUserAuditService
    {
        Task<IEnumerable<long>> GetPermissions(long userId, DateTime targetDate, CancellationToken cancellationToken);
    }
}