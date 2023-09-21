public partial class Program
{
    /// <summary>
    /// Get information about Sydney
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private static string[] GetTableForSydney(string[][] data)
    {
        //Создание листа и ввод в него строк, содержащую информацию по нужным условиям
        List<string> needData = new List<string>();
        needData.Add(GetStringFromArray(data[0]));

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i][1] == "Sydney" && (data[i][0].Contains("2009") || data[i][0].Contains("2010")))
            {
                needData.Add(GetStringFromArray(data[i]));
            }
        }

        return needData.ToArray();
    }

    /// <summary>
    /// Save a file
    /// </summary>
    /// <param name="table"></param>
    /// <param name="path"></param>
    private static void SaveInformation(string[] table, string path)
    {
        File.WriteAllLines(path, table);
        Console.WriteLine("Файл создан!");
        Console.WriteLine();
    }
}