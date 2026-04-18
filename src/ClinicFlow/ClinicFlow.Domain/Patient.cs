using System;

namespace ClinicFlow.Domain
{
    public class Patient
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}