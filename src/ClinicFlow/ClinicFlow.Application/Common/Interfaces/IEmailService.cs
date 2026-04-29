using System.Threading.Tasks;

namespace ClinicFlow.Application.Common.Interfaces;

public interface IEmailService
{
    Task SendAsync(string to, string subject, string body);
}
