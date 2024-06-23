using KolokwiumPoprawa.DTOs.Request;
using KolokwiumPoprawa.Repository;

namespace KolokwiumPoprawa.Service;

public class VisitService : IVisitService
{
    private IVisitRepository _visitRepository;
    
    public VisitService(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }

    public async Task<int> AddAppointment(AppointmentDTO appointmentDto)
    {
        var patient = _visitRepository.GetPatientAsync(appointmentDto.IdPatient);
        if (patient == null) throw new Exception("Patient not found");

        var doctor = _visitRepository.GetDoctorAsync(appointmentDto.IdDoctor);
        if (doctor == null) throw new Exception("Doctor not found");
        return 0;
    }
}