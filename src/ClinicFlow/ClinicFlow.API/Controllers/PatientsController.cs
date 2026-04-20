using ClinicFlow.API.Contracts.Patients;
using ClinicFlow.Domain.Entities;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomainUser = ClinicFlow.Domain.Entities.User;

namespace ClinicFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PatientsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientResponse>>> GetPatients()
    {
        var patients = await _context.Patients
            .Include(p => p.User)
            .Select(p => new PatientResponse
            {
                Id = p.Id,
                UserId = p.UserId,
                Email = p.User.Email,
                FirstName = p.User.FirstName,
                LastName = p.User.LastName,
                Phone = p.Phone,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                Address = p.Address,
                BloodType = p.BloodType,
                EmergencyContactName = p.EmergencyContactName,
                EmergencyContactPhone = p.EmergencyContactPhone
            })
            .ToListAsync();

        return Ok(patients);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PatientResponse>> GetPatientById(Guid id)
    {
        var patient = await _context.Patients
            .Include(p => p.User)
            .Where(p => p.Id == id)
            .Select(p => new PatientResponse
            {
                Id = p.Id,
                UserId = p.UserId,
                Email = p.User.Email,
                FirstName = p.User.FirstName,
                LastName = p.User.LastName,
                Phone = p.Phone,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                Address = p.Address,
                BloodType = p.BloodType,
                EmergencyContactName = p.EmergencyContactName,
                EmergencyContactPhone = p.EmergencyContactPhone
            })
            .FirstOrDefaultAsync();

        if (patient == null)
            return NotFound();

        return Ok(patient);
    }

    [HttpPost]
    public async Task<ActionResult<PatientResponse>> CreatePatient(CreatePatientRequest request)
    {
        var emailExists = await _context.Users
            .AnyAsync(u => u.Email == request.Email.ToLower().Trim());

        if (emailExists)
            return BadRequest("A user with that email already exists.");

        var user = DomainUser.Create(
            request.Email,
            request.Password,
            request.FirstName,
            request.LastName,
            UserRole.Patient);

        var patient = Patient.Create(
            user.Id,
            request.Phone,
            request.DateOfBirth,
            request.Gender,
            request.Address,
            request.BloodType);

        _context.Users.Add(user);
        _context.Patients.Add(patient);

        await _context.SaveChangesAsync();

        var response = new PatientResponse
        {
            Id = patient.Id,
            UserId = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Phone = patient.Phone,
            DateOfBirth = patient.DateOfBirth,
            Gender = patient.Gender,
            Address = patient.Address,
            BloodType = patient.BloodType,
            EmergencyContactName = patient.EmergencyContactName,
            EmergencyContactPhone = patient.EmergencyContactPhone
        };

        return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdatePatient(Guid id, UpdatePatientRequest request)
    {
        var patient = await _context.Patients.FindAsync(id);

        if (patient == null)
            return NotFound();

        patient.Update(
            request.Phone,
            request.Address,
            request.EmergencyContactName,
            request.EmergencyContactPhone);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePatient(Guid id)
    {
        var patient = await _context.Patients.FindAsync(id);

        if (patient == null)
            return NotFound();

        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}