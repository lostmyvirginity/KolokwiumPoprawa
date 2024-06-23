using KolokwiumPoprawa.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolokwiumPoprawa.Config;

public class VisitConfig : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.HasKey(v => v.IdVisit).HasName("Visit_PK");

        
        builder.Property(v => v.Date).IsRequired();
        builder.Property(v => v.Price).IsRequired();

        
        builder.HasOne(v => v.IdPatinetNav)
            .WithMany(p => p.Visits)
            .HasForeignKey(p => p.IdPatient)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(v => v.IdDoctorNav)
            .WithMany(d => d.Visits)
            .HasForeignKey(d => d.IdDoctor)
            .OnDelete(DeleteBehavior.Cascade);

        var visits = new List<Visit>()
        {
            new()
            {
                IdVisit = 1,
                Date = DateTime.Now,
                IdPatient = 1,
                IdDoctor = 1,
                Price = 123.2
            },
            new()
            {
                IdVisit = 2,
                Date = DateTime.Now,
                IdPatient = 2,
                IdDoctor = 2,
                Price = 150.2
            },
            new()
            {
                IdVisit = 3,
                Date = DateTime.Now,
                IdPatient = 3,
                IdDoctor = 3,
                Price = 50.2
            }
        };
        builder.HasData(visits);
    }
}