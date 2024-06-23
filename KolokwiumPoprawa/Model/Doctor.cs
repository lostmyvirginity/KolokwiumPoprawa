namespace KolokwiumPoprawa.Model;

public class Doctor
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialization { get; set; }
    public double PriceForVisit { get; set; }

    public virtual ICollection<Visit> Visits { get; set; }= new List<Visit>();
    public virtual ICollection<Schedule> Schedules { get; set; }= new List<Schedule>();
    
}