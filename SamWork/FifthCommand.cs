public partial class Program
{
    /// <summary>
    /// Return the number of days suitable for fishing
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private static int CountDaysFish(string[][] data)
    {
        int days = 0;
        for (int i = 0; i < data.Length; i++)
        {
            if (int.TryParse(data[i][12], out int wind) && wind < 13)
            {
                days++;
            }
        }

        return days;
    }

    /// <summary>
    /// Return the number of warm rainy days
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private static int CountDaysFishSun(string[][] data)
    {
        int days = 0;
        for (int i = 0; i < data.Length; i++)
        {
            if (int.TryParse(data[i][3], out int maxTemp) && maxTemp >= 20 && data[i][21] == "Yes")
            {
                days++;
            }
        }

        return days;
    }

    /// <summary>
    /// Return the number of days with normal atmospheric pressure
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private static int CountDaysPressure(string[][] data)
    {
        int days = 0;
        for (int i = 0; i < data.Length; i++)
        {
            if (double.TryParse(data[i][15], out double press) && press <= 1007 && press >= 1000)
            {
                days++;
            }
        }

        return days;
    }

    /// <summary>
    /// Print information about the location
    /// </summary>
    /// <param name="data"></param>
    private static void GetGroups(string[][] data)
    {
        HashSet<string> locations = new HashSet<string>();

        for (int i = 1; i < data.Length; i++)
        {
            locations.Add(data[i][1]);
        }

        Console.WriteLine($"Количество групп: {locations.Count}");

        var locationsCount = new Dictionary<string, int>();

        for (int i = 1; i < data.Length; i++)
        {
            if (locationsCount.ContainsKey(data[i][1]))
            {
                locationsCount[data[i][1]]++;
            }
            else
            {
                locationsCount[data[i][1]] = 1;
            }
        }

        Console.WriteLine("Количество записей в каждой группе:");

        foreach (var cl in locationsCount)
        {
            Console.WriteLine($"{cl.Key} - {cl.Value}");
        }
    }
}