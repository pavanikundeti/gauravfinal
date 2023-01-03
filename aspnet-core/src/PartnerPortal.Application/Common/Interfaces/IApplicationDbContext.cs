using Microsoft.EntityFrameworkCore;
using PartnerPortal.Domain.Entities;

namespace PartnerPortal.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Partner> Partners { get; }
        DbSet<ProjectManager> ProjectManagers { get; }
        DbSet<Country> Countries { get; }
        DbSet<Currency> Currencies { get; }
        DbSet<Department> Departments { get; }
        DbSet<Skill> Skills { get; }
        DbSet<RateCard> RateCards { get; }
        DbSet<Requisition> requisitions { get; }
        DbSet<RequisitionFile> RequisitionFiles { get; }
        DbSet<RequisitionJD> RequisitionJDs { get; }
        DbSet<RequisitionPartner>  RequisitionPartners { get; }
        DbSet<RequisitionSkill> RequisitionSkills { get; }

        DbSet<TodoList> TodoLists { get; }

        DbSet<TodoItem> TodoItems { get; }
       
        DbSet<PartnerSkill> PartnerSkills { get; }
        DbSet<ProjectManagerSkill> projectManagerSkills { get; }

        

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
