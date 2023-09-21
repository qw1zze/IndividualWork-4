public partial class Program
{
    /// <summary>
    /// Get a part of the table depending on Location
    /// </summary>
    /// <param name="data"></param>
    /// <param name="location"></param>
    /// <returns></returns>
    private static string[] GetTableForLocation(string[][] data, string location)
    {
        List<string> needData = new List<string>();
        needData.Add(GetStringFromArray(data[0]));

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i][1] == location)
            {
                needData.Add(GetStringFromArray(data[i]));
            }
        }

        return needData.ToArray();
    }

    /// <summary>
    /// Part table and get an array of rainfall values converted to double
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    private static double[] TableToArr(string[] table)
    {
        string[][] arr = DivideData(table);
        double[] rainfall = new double[arr.Length];

        for (int i = 1; i < arr.Length; i++)
        {
            if (double.TryParse(arr[i][4], out double el))
            {
                rainfall[i] = el;
            }
            else
            {
                rainfall[i] = 0;
            }
        }

        return rainfall;

    }

    /// <summary>
    /// Sort a part of the table by the rainfall column, as well as displaying the sorted table and returning the table
    /// </summary>
    /// <param name="table"></param>
    /// <param name="sortArr"></param>
    /// <returns></returns>
    private static string[] BubbleSort(string[] table, double[] sortArr)
    {
        double tempD;
        string tempS;
        for (int i = 1; i < sortArr.Length; i++)
        {
            for (int j = i + 1; j < sortArr.Length; j++)
            {
                if (sortArr[i] < sortArr[j])
                {
                    tempD = sortArr[i];
                    sortArr[i] = sortArr[j];
                    sortArr[j] = tempD;
                    tempS = table[i];
                    table[i] = table[j];
                    table[j] = tempS;

                }
            }
        }

        for (int i = 1; i < table.Length; i++)
        {
            Console.WriteLine(table[i]);
        }

        return table;
    }

    /// <summary>
    /// Returns the average value of the array
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    private static double SrZn(double[] arr)
    {
        double res = 0;
        foreach (double i in arr)
        {
            res += i;
        }

        return res / arr.Length;
    }

    /// <summary>
    /// Output tables that depend on locations and save to a file
    /// </summary>
    /// <param name="data"></param>
    private static void PrintGroups(string[][] data)
    {
        List<string> needData = new List<string>();
        needData.Add(GetStringFromArray(data[0]));
        HashSet<string> locations = new HashSet<string>();

        for (int i = 1; i < data.Length; i++)
        {
            locations.Add(data[i][1]);
        }

        foreach (string s in locations)
        {
            Console.WriteLine($"Location: {s}, Средний показатель осадков: {SrZn(TableToArr(GetTableForLocation(data, s)))}");
            foreach (var el in BubbleSort(GetTableForLocation(data, s), TableToArr(GetTableForLocation(data, s))))
            {
                if (!el.Contains("Date"))
                {
                    needData.Add(el);
                }

            };
            Console.WriteLine();
        }

        File.WriteAllLines("average_rain_weatherAUS.csv", needData.ToArray());
        Console.WriteLine("Файл Создан!");
    }
}