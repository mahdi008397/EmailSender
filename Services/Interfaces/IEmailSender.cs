using System.Threading.Tasks;

namespace Servises.Interfaces
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(string email, string message);
    }
}
