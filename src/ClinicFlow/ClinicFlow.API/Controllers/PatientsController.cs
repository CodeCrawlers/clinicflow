using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ClinicFlow.Application.Features.Patients.Dtos;
using ClinicFlow.Application.Features.Patients.Queries.GetPatients;
using ClinicFlow.Application.Features.Patients.Queries.GetPatientById;
using ClinicFlow.Application.Features.Patients.Commands.CreatePatient;
using ClinicFlow.Application.Features.Patients.Commands.UpdatePatient;
using ClinicFlow.Application.Features.Patients.Commands.DeletePatient;

namespace ClinicFlow.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns>List of all patients</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients()
        {
            var query = new GetPatientsQuery();
            var result = await _mediator.Send(query);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Data);
        }

        /// <summary>
        /// Get a patient by ID
        /// </summary>
        /// <param name="id">Patient ID</param>
        /// <returns>Patient details</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatientById(Guid id)
        {
            var query = new GetPatientByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }

            return Ok(result.Data);
        }

        /// <summary>
        /// Create a new patient
        /// </summary>
        /// <param name="createPatientDto">Patient data</param>
        /// <returns>Created patient details</returns>
        [HttpPost]
        public async Task<ActionResult<PatientDto>> CreatePatient([FromBody] CreatePatientDto createPatientDto)
        {
            var command = new CreatePatientCommand(createPatientDto);
            var result = await _mediator.Send(command);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetPatientById), new { id = result.Data?.Id }, result.Data);
        }

        /// <summary>
        /// Update an existing patient
        /// </summary>
        /// <param name="id">Patient ID</param>
        /// <param name="updatePatientDto">Updated patient data</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] UpdatePatientDto updatePatientDto)
        {
            var command = new UpdatePatientCommand(id, updatePatientDto);
            var result = await _mediator.Send(command);

            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }

            return NoContent();
        }

        /// <summary>
        /// Delete a patient
        /// </summary>
        /// <param name="id">Patient ID</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            var command = new DeletePatientCommand(id);
            var result = await _mediator.Send(command);

            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }

            return NoContent();
        }
    }
}