using Goldiran.Framework.Application.Helpers;
using Goldiran.Framework.Domain.Enums;
using NgCrm.BasicInfoService.Domain.Customers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.Domain.AuditLogs.Dtos;

public class AuditLogDto
{
    public long Id { get; set; }
    public Guid TransactionId { get; set; }
    public string EntityName { get; set; }
    public long? EntityId { get; set; }
    public Guid EntityBusinessId { get; set; }
    public ChangeTypes ChangeType { get; set; }
    //public string ChangeTypeTitle {get { return  ChangeType.GetEnumDescription(); } }
    public string ChangeTypeTitle { get { return string.Empty; } }
    public long UserId { get; set; }
    public string FullName { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
}
