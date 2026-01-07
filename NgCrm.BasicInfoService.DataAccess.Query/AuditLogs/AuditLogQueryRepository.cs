using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Extensions;
using Goldiran.Framework.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NgCrm.BasicInfoService.Domain.AuditLogs.Contracts;
using NgCrm.BasicInfoService.Domain.AuditLogs.Dtos;
using NgCrm.BasicInfoService.Domain.AuditLogs.Queries;
using NgCrm.BasicInfoService.Domain.Common.Attributes;
using NgCrm.BasicInfoService.Domain.Users.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.DataAccess.Query.AuditLogs;

public class AuditLogQueryRepository : IAuditLogQueryRepository
{
    private BasicInfoQueryContext _dbContext { get; set; }

    public AuditLogQueryRepository(BasicInfoQueryContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Paged<AuditLogDto>> GetAuditLogs(GetAuditLogQuery filter, CancellationToken cancellationToken)
    {
        var query = from log in _dbContext.AuditLogs
                    join user in _dbContext.Users on log.UserId equals user.Id
                    where (filter.ChangeType!=null?filter.ChangeType==log.ChangeType:true) &&
                          (filter.EntityName != null ? filter.EntityName.ToString() == log.EntityName : true) &&
                          (filter.UserId != null ? filter.UserId == log.UserId : true) &&
                          (filter.EntityId != null ? filter.EntityId == log.EntityId : true)
                    orderby log.Id descending
                    select new { log,user };

        var count = query.Count();

        var entities = await query
        .Skip((filter.FilterInfo.PageNumber - 1) * filter.FilterInfo.PageNumber)
            .Take(filter.FilterInfo.PageNumber).ToListAsync();

        var dtos = new List<AuditLogDto>();

        foreach (var entity in entities)
        {
            var dto = new AuditLogDto()
            {
                Id = entity.log.Id,
                TransactionId = entity.log.TransactionId,
                EntityBusinessId = entity.log.EntityBusinessId,
                CreatedAt = entity.log.CreatedAt,
                ChangeType = entity.log.ChangeType,
                EntityId=entity.log.EntityId,
                EntityName = entity.log.EntityName,
                FullName = entity.user.Username,
                UserId=entity.log.UserId,
            };

            dtos.Add(dto);
        }

        return new Paged<AuditLogDto>(dtos, filter.FilterInfo.PageNumber, filter.FilterInfo.PageSize, count);

    }

    public async Task<AuditLogDetailsDto> GetByIdAsync(long id)
    {
        var entity =await  _dbContext.AuditLogs.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        //
        var dto = new AuditLogDetailsDto();

        Type type = Type.GetType($"NgCrm.BasicInfoService.Domain.{entity.EntityName}s.ReadModels.{entity.EntityName}ReadModel,NgCrm.BasicInfoService.Domain");

        dto.JsonOldValues = entity.OldValues;
        dto.JsonNewValues = entity.NewValues;

        if (!string.IsNullOrEmpty(entity.OldValues))
            dto.OldValues = GetAuditLogDetails(type, entity.OldValues);

        if (!string.IsNullOrEmpty(entity.NewValues))
            dto.NewValues = GetAuditLogDetails(type, entity.NewValues);

        if((!string.IsNullOrEmpty(entity.OldValues) && dto.OldValues.IsNullOrEmpty()) ||
            (!string.IsNullOrEmpty(entity.NewValues) && dto.NewValues.IsNullOrEmpty()))
            dto.IsSuccess = false;

        return dto;
    }

    private IList<AuditLogValue> GetAuditLogDetails(Type type, string value)
    {
        var dtoList=new List<AuditLogValue>();

        try
        {
            dynamic val = JsonConvert.DeserializeObject(value, type);

            var props = type.GetProperties().ToList();

            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttributes(typeof(DtoAttributes), true);
                if (!attr.IsNullOrEmpty())
                {

                    if (attr[0] is DtoAttributes a && a.IsDisplayed)
                    {
                        var dto = new AuditLogValue();
                        dto.Name = a.Name;
                        dto.Value = prop.GetValue(val);
                        dtoList.Add(dto);
                    }
                }

            }
        }
        catch (Exception ex)
        {

            return dtoList;
        }
        

        return dtoList;
    }
        
}
