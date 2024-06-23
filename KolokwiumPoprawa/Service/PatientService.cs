using KolokwiumPoprawa.DTOs;
using KolokwiumPoprawa.Model;
using KolokwiumPoprawa.Repository;

namespace KolokwiumPoprawa.Service;

public class PatientService : IPatientService
{
    private IPatientRepository _patientRepository;
    
    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    public async Task<PatientDTO> GetPatientAsync(int id)
    {
        var patient = await _patientRepository.GetPatientAsync(id);
        if (patient == null) throw new Exception("Patient not found");
        return new PatientDTO()
        {
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthdate = patient.Date,
            TotalAmountSpent = GetTotalAmount(patient),
            NumbersOfVisit = GetNumberOfVisits(patient),

        };
    }
    
    private double GetTotalAmount(Patient p)
    {
        var sum = 0.0;
        foreach (var visit in p.Visits)
        {
            sum += visit.Price;
        }
        return sum;
    }
    private int GetNumberOfVisits(Patient p)
    {
        var sum = 0;
        foreach (var visit in p.Visits)
        {
            sum++;
        }
        return sum;
    }
}