using KolokwiumPoprawa.DTOs.Request;
using KolokwiumPoprawa.Service;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumPoprawa.Controller;

[ApiController]
[Route("[controller]")]
public class VisitController : ControllerBase
{
    private IVisitService _visitService;
    
    public VisitController(IVisitService visitService)
    {
        _visitService = visitService;
    }
    
    [HttpPost]
    public async Task<IActionResult> GetPatient(AppointmentDTO vi)
    {
        try
        {
            var appointment = await _visitService.AddAppointment(vi);
            return Ok(appointment);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}