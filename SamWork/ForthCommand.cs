public partial class Program
{
    /// <summary>
    /// Get a part of the table depending on Sunshine
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private static string[] GetTableForSunshine(string[][] data)
    {
        List<string> needData = new List<string>();
        needData.Add(GetStringFromArray(data[0]));

        int maxSun = 0;
        string date = "", maxTemp = "";
        for (int i = 0; i < data.Length; i++)
        {
            if (int.TryParse(data[i][6], out int actSun) && actSun >= 4)
            {
                needData.Add(GetStringFromArray(data[i]));

                if (actSun > maxSun)
                {
                    maxSun = actSun;
                    maxTemp = data[i][3];
                    date = data[i][0];
                }
            }
        }

        Console.WriteLine($"Дата: {date}, максимальная температура: {maxTemp}");

        return needData.ToArray();
    }

    /// <summary>
    /// Creates a file with a custom name
    /// </summary>
    /// <param name="table"></param>
    private static void InputSaveFile(string[] table)
    {
        while (true)
        {
            try
            {
                Console.Write("Введите название файла без расширения: ");
                string file = Console.ReadLine();
                SaveInformation(table, $"{file}.csv");
                break;
            }
            catch (IOException ex)
            {
                Console.WriteLine("Неверное название файла.");
                continue;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Неизвестная ошибка!");
                continue;
            }
        }
    }
}