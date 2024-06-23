using KolokwiumPoprawa.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolokwiumPoprawa.Config;

public class DoctorConfig : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(d => d.IdDoctor).HasName("Doctor_PK");

        builder.Property(d => d.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(d => d.LastName).HasMaxLength(100).IsRequired();
        builder.Property(d => d.Specialization).HasMaxLength(100).IsRequired();
        builder.Property(d => d.PriceForVisit).IsRequired();

        builder.HasMany(d => d.Visits)
            .WithOne(v => v.IdDoctorNav)
            .HasForeignKey(v => v.IdDoctor)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.Schedules)
            .WithOne(s => s.IdDoctorNav)
            .HasForeignKey(s => s.IdDoctor)
            .OnDelete(DeleteBehavior.Cascade);

        var doctors = new List<Doctor>
        {
            
            new ()
            {
                IdDoctor = 1,
                FirstName = "Test",
                LastName = "Test",
                Specialization = "Tstowa",
                PriceForVisit = 123.0,
                
                
            },
            new ()
            {
                IdDoctor = 2,
                FirstName = "x",
                LastName = "d",
                Specialization = "Neuropatia",
                PriceForVisit = 643.3
            },
            new ()
            {
                IdDoctor = 3,
                FirstName = "Mikołaj",
                LastName = "Nowy",
                Specialization = "Kardio",
                PriceForVisit = 50.0,
            },
        };
        builder.HasData(doctors);
    }
}