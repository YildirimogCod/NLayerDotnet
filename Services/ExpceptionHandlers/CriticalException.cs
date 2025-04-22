namespace App.Services.ExpceptionHandlers
{
    public class CriticalException(string message):Exception(message)
    {
    }
}
