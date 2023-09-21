using System.Text;

public partial class Program
{
    /// <summary>
    /// Get a string from an array of strings
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    private static string GetStringFromArray(string[] arr)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < arr.Length; i++)
        {
            sb.Append(arr[i] + ',');
        }

        return sb.ToString();

    }

    /// <summary>
    /// Table output
    /// </summary>
    /// <param name="table"></param>
    private static void PrintTable(string[] table)
    {
        for (int i = 0; i < table.Length; i++)
        {
            Console.WriteLine(table[i]);
        }
    }
}