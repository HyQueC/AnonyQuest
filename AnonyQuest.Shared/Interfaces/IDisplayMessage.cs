using System.Threading.Tasks;

namespace AnonyQuest.Shared.Interfaces
{
    public interface IDisplayMessage
    {
        ValueTask DisplayErrorMessage(string message);
        ValueTask DisplaySuccessMessage(string message);
    }
}
