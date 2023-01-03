using Duende.IdentityServer.EntityFramework.Options;
using Duende.IdentityServer.Hosting.DynamicProviders;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Infrastructure.Identity;
using PartnerPortal.Infrastructure.Persistence.Interceptors;
using System.Reflection;

namespace PartnerPortal.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly IMediator _mediator;
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
		public readonly object IdentityUsers;
		public readonly object AspNetUsers;

		public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            IMediator mediator,
            AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
            : base(options, operationalStoreOptions)
        {
            _mediator = mediator;
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }


        public DbSet<Partner> Partners => Set<Partner>();

        public DbSet<Functionality> Functionalities => Set<Functionality>();
        public DbSet<RolesPermission> RolePermissions => Set<RolesPermission>();
        public DbSet<RoleDescription> RoleDescriptions => Set<RoleDescription>();
        public object User { get; set; }
        public DbSet<Skill> Skills => Set<Skill>();
        public DbSet<RateCard> RateCards => Set<RateCard>();
        public DbSet<Requisition> requisitions => Set<Requisition>();
        public DbSet<RequisitionFile> RequisitionFiles => Set<RequisitionFile>();
        public DbSet<ProjectManager> ProjectManagers=> Set<ProjectManager>();

        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Currency> Currencies => Set<Currency>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<RequisitionJD> RequisitionJDs => Set<RequisitionJD>();
        public DbSet<RequisitionPartner> RequisitionPartners => Set<RequisitionPartner>();
        public DbSet<RequisitionSkill> RequisitionSkills => Set<RequisitionSkill>();
        public DbSet<PartnerSkill> PartnerSkills => Set<PartnerSkill>();

        public DbSet<TodoList> TodoLists => Set<TodoList>();

        public DbSet<TodoItem> TodoItems => Set<TodoItem>();

		public object IdentityUser { get; set; }
		public object RegisterUser { get; set; }
		public object Reg_user { get; set; }
        public DbSet<ProjectManagerSkill> projectManagerSkills=>Set<ProjectManagerSkill>();

        public DbSet<EmailTemplate> EmailTemplates => Set<EmailTemplate>();


		protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
            SeedRoles(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }
		public static void SeedRoles(ModelBuilder builder)
		{
			builder.Entity<IdentityRole>().HasData
			(
			new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
			new IdentityRole() { Name = "ProjectManager", ConcurrencyStamp = "2", NormalizedName = "PROJECTMANAGER" },
			new IdentityRole() { Name = "Partner", ConcurrencyStamp = "3", NormalizedName = "PARTNER" },
			new IdentityRole() { Name = "Sales", ConcurrencyStamp = "4", NormalizedName = "SALES" },
			new IdentityRole() { Name = "Ops", ConcurrencyStamp = "5", NormalizedName = "OPS" }

			);
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
