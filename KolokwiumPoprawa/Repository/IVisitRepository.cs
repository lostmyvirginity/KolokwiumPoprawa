using KolokwiumPoprawa.Model;

namespace KolokwiumPoprawa.Repository;

public interface IVisitRepository
{
    Task<Patient> GetPatientAsync(int id);
    Task<Doctor> GetDoctorAsync(int id);
}