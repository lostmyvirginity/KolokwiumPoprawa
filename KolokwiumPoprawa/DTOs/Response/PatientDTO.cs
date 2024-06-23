using KolokwiumPoprawa.Model;

namespace KolokwiumPoprawa.DTOs;

public class PatientDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public double TotalAmountSpent { get; set; }
    public int NumbersOfVisit { get; set; }
    public List<Visit> Visits { get; set; }
}