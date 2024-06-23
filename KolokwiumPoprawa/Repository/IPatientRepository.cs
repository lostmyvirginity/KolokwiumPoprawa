using KolokwiumPoprawa.Model;

namespace KolokwiumPoprawa.Repository;

public interface IPatientRepository
{
    Task<Patient> GetPatientAsync(int id);
}