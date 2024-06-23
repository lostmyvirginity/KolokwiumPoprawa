using KolokwiumPoprawa.Model;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumPoprawa.Repository;

public class VisitRepository(ContextApp contextApp) : IVisitRepository
{
    public async Task<Patient> GetPatientAsync(int id)
    {
        return (await contextApp.Patients
            .FirstOrDefaultAsync(p=>p.IdPatient == id))!;
    }
    public async Task<Doctor> GetDoctorAsync(int id)
    {
        return (await contextApp.Doctors
            .FirstOrDefaultAsync(p=>p.IdDoctor == id))!;
    }
    
}