using KolokwiumPoprawa.DTOs.Request;

namespace KolokwiumPoprawa.Service;

public interface IVisitService
{
    Task<int> AddAppointment(AppointmentDTO appointmentDto);
}