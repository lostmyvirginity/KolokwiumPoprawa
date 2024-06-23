using KolokwiumPoprawa.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolokwiumPoprawa.Config;

public class ScheduleConfig : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.HasKey(s => s.IdSchedule).HasName("Schedule_PK");

        builder.Property(s => s.DateFrom).IsRequired();
        builder.Property(s => s.DateTo).IsRequired();

        builder.HasOne(s => s.IdDoctorNav)
            .WithMany(d => d.Schedules)
            .HasForeignKey(d => d.IdSchedule)
            .OnDelete(DeleteBehavior.Cascade);

        var Schedules = new List<Schedule>
        {
            
            new()
            {
                IdSchedule = 1,
                IdDoctor = 1,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now,
            },
            new()
            {
                IdSchedule = 2,
                IdDoctor = 2,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now,
            },
            new()
            {
                IdSchedule = 3,
                IdDoctor = 3,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now,
            },
        };
        builder.HasData(Schedules);
    }
}