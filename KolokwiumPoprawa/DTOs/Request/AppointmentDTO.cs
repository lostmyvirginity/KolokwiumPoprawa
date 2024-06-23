namespace KolokwiumPoprawa.DTOs.Request;

public class AppointmentDTO
{
    public int IdDoctor { get; set; }
    public int IdPatient { get; set; }
    public DateTime Date { get; set; }
}