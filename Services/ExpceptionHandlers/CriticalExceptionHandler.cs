using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace App.Services.ExpceptionHandlers
{
    public class CriticalExceptionHandler:IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
           //business logic
           if (exception is CriticalException)
           {
               Console.WriteLine("Sms gönderildi.");
           }

           return ValueTask.FromResult(false);
        }
    }
}
