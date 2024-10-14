using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context;

public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Accounts> Accounts { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanySmtp> CompanySmtps { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<CandidateSkill> CandidateSkills { get; set; }
    public DbSet<CandidateExperiance> CandidateExperiances { get; set; }
    public DbSet<Form> Forms { get; set; }
    public DbSet<CandidateApplication> CandidateApplications { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Form>()
            .HasMany<CandidateApplication>()
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<CandidateApplication>()
            .HasOne<Form>()
            .WithMany()
            .HasForeignKey(ca => ca.FormId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}