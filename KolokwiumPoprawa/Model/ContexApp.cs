using Microsoft.EntityFrameworkCore;

namespace KolokwiumPoprawa.Model;


public class ContextApp : DbContext
{
    public ContextApp()
    {
    }

    public ContextApp(DbContextOptions<ContextApp> options) : base(options)
    {
    }

    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Visit> Visits { get; set; }
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Schedule> Schedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextApp).Assembly);
    }
}