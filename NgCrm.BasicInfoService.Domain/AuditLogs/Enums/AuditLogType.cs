using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.Domain.AuditLogs.Enums;

public enum AuditLogType
{
    [Description("مشتریان")]
    Customer = 1,
}
