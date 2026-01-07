using Goldiran.Framework.EFCore;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.AccessGroups.ReadModels;
using NgCrm.BasicInfoService.Domain.ADUsers.ReadModels;
using NgCrm.BasicInfoService.Domain.BaseInfos.ReadModels;
using NgCrm.BasicInfoService.Domain.Customers.ReadModels;
using NgCrm.BasicInfoService.Domain.Departments.ReadModels;
using NgCrm.BasicInfoService.Domain.Locations.ReadModels;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.ReadModels;
using NgCrm.BasicInfoService.Domain.Organizations.ReadModels;
using NgCrm.BasicInfoService.Domain.Permissions.ReadModels;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.ReadModels;
using NgCrm.BasicInfoService.Domain.PersonDelegates.ReadModels;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;
using NgCrm.BasicInfoService.Domain.Positions.ReadModels;
using NgCrm.BasicInfoService.Domain.Roles.ReadModels;
using NgCrm.BasicInfoService.Domain.Users.ReadModels;
using NgCrm.BasicInfoService.Domain.Workspaces.ReadModels;
using System.Reflection;

namespace NgCrm.BasicInfoService.DataAccess.Query
{
    public class BasicInfoQueryContext : QueryDbContext
    {
        public BasicInfoQueryContext(DbContextOptions<BasicInfoQueryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override string AuditLogTable => "AuditLogs";
        protected override string AuditLogSchema => "BSI";

        //public DbSet<OrganizationReadModel> Organizations { get; set; }
        public DbSet<RoleReadModel> Roles { get; set; }
        public DbSet<OrganizationReadModel> Organizations { get; set; }
        public DbSet<WorkspaceReadModel> Workspaces { get; set; }
        public DbSet<PositionReadModel> Positions { get; set; }
        public DbSet<PositionPermissionReadModel> PositionPermissions { get; set; }
        public DbSet<PermissionReadModel> Permissions { get; set; }
        public DbSet<ADUserReadModel> ADUsers { get; set; }
        public DbSet<UserReadModel> Users { get; set; }
        public DbSet<WorkspacePermissionReadModel> WorkspacePermissions { get; set; }
        public DbSet<PersonReadModel> Persons { get; set; }
        public DbSet<PersonAddressReadModel> PersonAddresses { get; set; }
        public DbSet<PersonContactReadModel> PersonContacts { get; set; }
        public DbSet<LocationReadModel> Locations { get; set; }
        public DbSet<PersonPositionReadModel> PersonPositions { get; set; }
        public DbSet<PersonPositionPermissionReadModel> PersonPositionPermissions { get; set; }
        public DbSet<OrganizationHistoryReadModel> OrganizationHistories { get; set; }
        public DbSet<DepartmentReadModel> Departments { get; set; }
        public DbSet<BaseInfoReadModel> BaseInfos { get; set; }
        public DbSet<CustomerReadModel> Customers { get; set; }
        public DbSet<CustomerAddressReadModel> CustomerAddresses { get; set; }
        public DbSet<CustomerContactReadModel> CustomerContacts { get; set; }
        public DbSet<CustomerRelationReadModel> CustomerRelations { get; set; }
        public DbSet<AccessGroupReadModel> AccessGroups { get; set; }
        public DbSet<PersonAccessGroupReadModel> PersonAccessGroups { get; set; }
        public DbSet<PersonDelegateReadModel> PersonDelegates { get; set; }
    }
}
