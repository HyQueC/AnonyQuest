using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AnonyQuest.Components.Helpers
{
    public static class IJSRuntimeExtensionMethods
    {
        public static async ValueTask<bool> Confirm(this IJSRuntime js, string message)
        {
            return await js.InvokeAsync<bool>("confirm", message);
        }

    }
}
