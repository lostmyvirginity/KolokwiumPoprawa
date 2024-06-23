using KolokwiumPoprawa.Service;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumPoprawa.Controller;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    private IPatientService _patientService;
    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        try
        {
            var patient = await _patientService.GetPatientAsync(id);
            return Ok(patient);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}