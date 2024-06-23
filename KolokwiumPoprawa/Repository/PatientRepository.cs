using KolokwiumPoprawa.Model;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumPoprawa.Repository;

public class PatientRepository(ContextApp contextApp) : IPatientRepository
{
    public async Task<Patient> GetPatientAsync(int id)
    {
        return (await contextApp.Patients
            .Include(p=>p.Visits)
            .FirstOrDefaultAsync(p=>p.IdPatient == id))!;
            
    }
}