using Goldiran.Framework.Domain.Services;
using Goldiran.Framework.EFCore;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.AccessGroups.Entities;
using NgCrm.BasicInfoService.Domain.ADUsers.Entities;
using NgCrm.BasicInfoService.Domain.BaseInfos.Entities;
using NgCrm.BasicInfoService.Domain.Customers.Entities;
using NgCrm.BasicInfoService.Domain.Departments.Entities;
using NgCrm.BasicInfoService.Domain.Locations.Entities;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Entities;
using NgCrm.BasicInfoService.Domain.Organizations.Entities;
using NgCrm.BasicInfoService.Domain.Permissions.Entities;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Entities;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Entities;
using NgCrm.BasicInfoService.Domain.Persons.Entities;
using NgCrm.BasicInfoService.Domain.Positions.Entities;
using NgCrm.BasicInfoService.Domain.Roles.Entities;
using NgCrm.BasicInfoService.Domain.Workspaces.Entities;
using System.Reflection;

namespace NgCrm.BasicInfoService.DataAccess.Command
{
    public class BasicInfoCommandContext : CommandDbContext
    {
        public BasicInfoCommandContext(DbContextOptions<BasicInfoCommandContext> options, ICurrentUserService currentUserService) : base(options, currentUserService)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ADUser> ADUsers { get; set; }
        public DbSet<WorkspacePermission> WorkspacePermissions { get; set; }
        public DbSet<PositionPermission> PositionPermissions { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<BaseInfo> BaseInfos { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }
        public DbSet<CustomerRelation> CustomerRelations { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<PersonPositionPermission> PersonPositionPermissions { get; set; }
        public DbSet<OrganizationHistory> OrganizationHistories { get; set; }
        public DbSet<AccessGroup> AccessGroups { get; set; }
        public DbSet<PersonAccessGroup> PersonAccessGroups { get; set; }
        public DbSet<PersonDelegate> PersonDelegates { get; set; }

        protected override string OutboxMessageTable => "OutboxMessages";
        protected override string OutboxMessageSchema => "BSI";

        protected override string InboxMessageTable => "InboxMessages";
        protected override string InboxMessageSchema => "BSI";

        protected override string AuditLogTable => "AuditLogs";
        protected override string AuditLogSchema => "BSI";
    }
}
