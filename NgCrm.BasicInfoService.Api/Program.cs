
using Goldiran.Framework.AspNetCore.Filters;
using Goldiran.Framework.AspNetCore.Middlewares;
using Goldiran.Framework.DependencyInjection;
using NgCrm.BasicInfoService.Api.BackgroundTasks;
using NgCrm.BasicInfoService.Application.Organizations.Commands;
using NgCrm.BasicInfoService.Application.Persons.Services;
using NgCrm.BasicInfoService.Application.Roles.Commands;
using NgCrm.BasicInfoService.Application.Users.Services;
using NgCrm.BasicInfoService.DataAccess.Command;
using NgCrm.BasicInfoService.DataAccess.Command.Users;
using NgCrm.BasicInfoService.DataAccess.Query;
using NgCrm.BasicInfoService.DataAccess.Query.Roles;
using NgCrm.BasicInfoService.Domain.Common.Models;
using NgCrm.BasicInfoService.Domain.Persons.Services;
using NgCrm.BasicInfoService.Domain.Users.Services;
using NgCrm.BasicInfoService.Integration.Roles;
using NgCrm.BasicInfoService.Mapping.Roles;
using NgCrm.BasicInfoService.Proxy.AD;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<AppSetting>(builder.Configuration);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddProblemDetails();

builder.Services.AddGoldiran(options =>
    {
        options.AddRepositories(typeof(RoleQueryRepository).Assembly, typeof(UserCommandRepository).Assembly);
        options.AddValidationConfig(typeof(CreateRoleCommandValidator));
        options.AddDomainServices(typeof(ADMembershipService).Assembly);
        options.AddAuditServices(typeof(RoleQueryRepository).Assembly);
        options.AddProxies(typeof(ADDataProxy).Assembly);
        options.AddApplicationPipelines(typeof(CreateOrganizationCommand));
        options.AddMapster(typeof(RoleMapping).Assembly);
        options.AddSeqLogging(builder.Configuration.GetSection("Seq"));
        options.AddCommandDbContext<BasicInfoCommandContext>(builder.Configuration.GetConnectionString("CommandConnection")!);
        options.AddQueryDbContext<BasicInfoQueryContext>(builder.Configuration.GetConnectionString("QueryConnection")!);
        options.AddInMemoryCache();
        options.AddSwaggerConfig("NgCrm.BasicInfoService", "V1");
        options.AddJwtAuthentician(builder.Configuration["JwtConfig:Issuer"]!, builder.Configuration["JwtConfig:Secret"]!);
    })
.AddMassTransitConfig(x =>
    {
        x.SetHost(builder.Configuration["RabbitMQ:Server"]!)
         .SetUserName(builder.Configuration["RabbitMQ:UserName"]!)
         .SetPassword(builder.Configuration["RabbitMQ:Password"]!)
         .SetDeliveryRetryCount(5)
         .SetDeliveryRetryPeriodSecond(5)
         .SetIntegrationEventAssembly(typeof(RoleCreatedMessage).Assembly)
         .SetMessageHandlerAssembly(Assembly.GetExecutingAssembly());
    })
.AddOutbox(options =>
    {
        options.UseDbContext<BasicInfoCommandContext>(builder.Services);
        options.UseOutboxHostedPublisher(builder.Services, hsOptions =>
        {
            hsOptions.Delay = 10000;
        });
    })
.AddInbox(options =>
{
    options.UseDbContext<BasicInfoCommandContext>(builder.Services);
    options.UseInboxHostedProccessor(builder.Services, hsOptions =>
    {
        hsOptions.Delay = 10000;
    });
});

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddHostedService<ADDataFetchTask>();
builder.Services.AddHostedService<MapDataProxyFetchTask>();
builder.Services.AddHttpClient();

builder.Services.AddAuthorization();

builder.Services.AddControllers(options =>
{
    options.ModelValidatorProviders.Clear();
    options.Filters.Add<ApiExceptionFilterAttribute>();
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(corsBuilder =>
{
    corsBuilder.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

//app.UseMiddleware<JwtMiddleware>();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GoldiranExceptionHandler>();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();



