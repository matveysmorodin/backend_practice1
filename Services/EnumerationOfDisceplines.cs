namespace web_1try.Services;

public class EnumerationOfDisceplines
{
    public string DisceplinesEnumerate()
    {
        var disceplines = new List<string>()
        {
            "Back-end разработка",
            "Базы данных",
            "Веб-программирование и дизайн",
            "Системный анализ", 
            "Английский язык",
            "Физическая культура",
            "и др."
        };

        string result = "";
        for (int i = 0; i < disceplines.Count; i++)
        {
            result += disceplines[i] + "\n";
        }

        return result;

    }
    
    
}