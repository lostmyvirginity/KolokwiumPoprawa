using KolokwiumPoprawa.DTOs;

namespace KolokwiumPoprawa.Service;

public interface IPatientService
{
    Task<PatientDTO> GetPatientAsync(int id);
}