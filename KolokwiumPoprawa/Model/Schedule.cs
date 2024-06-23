namespace KolokwiumPoprawa.Model;

public class Schedule
{
    public int IdSchedule { get; set; }
    public int IdDoctor { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }

    public virtual Doctor IdDoctorNav { get; set; } = null!;
}