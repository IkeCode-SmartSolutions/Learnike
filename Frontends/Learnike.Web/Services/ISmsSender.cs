using System.Threading.Tasks;

namespace Learnike.Web.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
