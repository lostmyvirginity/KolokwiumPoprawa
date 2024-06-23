namespace KolokwiumPoprawa.Model;

public class Patient
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Date { get; set; }
    
    public virtual ICollection<Visit> Visits { get; set; }= new List<Visit>();
}