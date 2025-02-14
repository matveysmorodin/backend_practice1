namespace web_1try.Services;

public class TimeClientNow
{
    public string PrintTime()
    {
        return $"Client time is {DateTime.Now}";
    }
}