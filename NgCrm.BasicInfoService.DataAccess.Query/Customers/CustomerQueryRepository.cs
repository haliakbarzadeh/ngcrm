using Goldiran.Framework.Domain.Models;
using Goldiran.Framework.EFCore.Common;
using Goldiran.Framework.EFCore.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Customers.Contracts;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;
using NgCrm.BasicInfoService.Domain.Customers.Queries;
using NgCrm.BasicInfoService.Domain.Customers.ReadModels;
using System.IO;

namespace NgCrm.BasicInfoService.DataAccess.Query.Customers
{
    public class CustomerQueryRepository : QueryRepository<CustomerReadModel, BasicInfoQueryContext>, ICustomerQueryRepository
    {
        public CustomerQueryRepository(BasicInfoQueryContext dbContext) : base(dbContext)
        {

        }

        public async Task<Paged<CustomerDto>> GetCustomers(GetCustomerQuery filter, CancellationToken cancellationToken)
        {
            var result = await DbContext.Customers.AsNoTracking()
                                .Include(c => c.CustomerAddresses)
                                .Include(c => c.CustomerRelations)
                                .Include(c => c.CustomerContacts)
                                .Include(c => c.CustomerTitle)
                                .Include(c => c.Nationality)
                            .Where(c => (filter.IsDeleted != null ? filter.IsDeleted==c.IsDeleted: true) &&
                                        (filter.FirstName != null ? EF.Functions.Like(c.FirstName, $"%'{filter.FirstName}'%") : true) &&
                                        (filter.LastName != null ? EF.Functions.Like(c.LastName, $"%'{filter.FirstName}'%") : true) &&
                                        (filter.CompanyName != null ? EF.Functions.Like(c.CompanyName, $"%'{filter.CompanyName}'%") : true) &&
                                        (filter.BrandName != null ? EF.Functions.Like(c.BrandName, $"%'{filter.BrandName}'%") : true) &&
                                        (filter.NationalCode != null ? EF.Functions.Like(c.NationalCode, $"%'{filter.NationalCode}'%") : true) &&
                                        (filter.Contact != null ? c.CustomerContacts.Any(d => EF.Functions.Like(d.Contact, $"%'{filter.Contact}'%")) : true) &&
                                        (filter.IsIranian != null ? c.IsIranian == filter.IsIranian : true) &&
                                        (filter.IsActive != null ? c.IsActive == filter.IsActive : true) &&
                                        (filter.GenderTypeId != null ? c.GenderTypeId == filter.GenderTypeId : true) &&
                                        (filter.CustomerTypeId != null ? c.CustomerTypeId == filter.CustomerTypeId : true) &&
                                        (filter.VipReasonTypeId != null ? c.VipReasonTypeId == filter.VipReasonTypeId : true) &&
                                        (!string.IsNullOrEmpty(filter.FilterInfo.Search) ? EF.Functions.Like(c.FirstName, $"%'{filter.FilterInfo.Search}'%") || EF.Functions.Like(c.LastName, $"%'{filter.FilterInfo.Search}'%") || EF.Functions.Like(c.NationalCode, $"%'{filter.FilterInfo.Search}'%") || EF.Functions.Like(c.CompanyName, $"%'{filter.FilterInfo.Search}'%") : true))
                            .OrderByDescending(x => x.Id)
                            .ProjectToType<CustomerDto>()
                            .ToPagedListAsync(filter.FilterInfo, cancellationToken);

            return result;
        }

    }
}
