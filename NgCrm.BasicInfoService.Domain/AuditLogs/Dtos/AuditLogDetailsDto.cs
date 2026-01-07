using Goldiran.Framework.Application.Helpers;
using Goldiran.Framework.Domain.Enums;
using NgCrm.BasicInfoService.Domain.Customers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.Domain.AuditLogs.Dtos;

public class AuditLogDetailsDto
{
    public bool IsSuccess { get; set; } = true;
    public string JsonOldValues {  get; set; }
    public IList<AuditLogValue> OldValues { get; set; } = new List<AuditLogValue>();
    public string JsonNewValues { get; set; }
    public IList<AuditLogValue> NewValues { get; set; } = new List<AuditLogValue>();

}

public class AuditLogValue
{
    public string Name {  get; set; }
    public object Value { get; set; }
}
