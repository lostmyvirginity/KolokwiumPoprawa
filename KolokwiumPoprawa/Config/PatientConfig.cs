using KolokwiumPoprawa.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolokwiumPoprawa.Config;

public class PatientConfig : IEntityTypeConfiguration<Patient>

{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(c => c.IdPatient).HasName("Patient_PK");
        builder.Property(c => c.IdPatient).UseIdentityColumn();

        builder.Property(c => c.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(c => c.LastName).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Date).IsRequired();

        builder.HasMany(c => c.Visits)
            .WithOne(v => v.IdPatinetNav)
            .HasForeignKey(v => v.IdPatient)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("Patient_Visit_FK");

        var patients = new List<Patient>
        {
            new()
            {
                IdPatient = 1,
                FirstName = "Ala",
                LastName = "Ma kota",
                Date = DateTime.Now
            },
            new()
            {
                IdPatient = 2,
                FirstName = "Karol",
                LastName = "Karo",
                Date = DateTime.Now
            },
            new()
            {
                IdPatient = 3,
                FirstName = "Kamil",
                LastName = "Bąk",
                Date = DateTime.Now
            },
            new()
            {
                IdPatient = 4,
                FirstName = "Jacob",
                LastName = "Testowski",
                Date = DateTime.Now
            },
        };
        builder.HasData(patients);
    }
    
    
}