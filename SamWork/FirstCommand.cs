public partial class Program
{
    /// <summary>
    /// Changes information in the data array, which is taken from a file entered by the user
    /// </summary>
    /// <param name="data"></param>
    private static void ChangeData(ref string[][] data)
    {
        string[][] tempData;
        //Checking the path and requesting the path again if the path is incorrect
        while (true)
        {
            try
            {
                tempData = DivideData(File.ReadAllLines(InputPath()));
                break;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Файл не сущеуствует. Попробуйте ввести путь снова: ");
                continue;
            }
            catch (IOException ex)
            {
                Console.WriteLine("Путь содержит недопустимые символы. Попробуйте ввести путь снова: ");
                continue;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Неизвестная ошибка!");
                continue;
            }
        }

        if (CheckStructure(tempData))
        {
            data = tempData;
            Console.WriteLine("Файл успешно открыт!");
        }
        else
        {
            Console.WriteLine("Неверная структура файла. Попробуйте другой файл.");
        }

    }

    /// <summary>
    /// Checks the file structure
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private static bool CheckStructure(string[][] data)
    {
        string[] structure = { "Date", "Location", "MinTemp", "MaxTemp", "Rainfall", "Evaporation", "Sunshine", "WindGustDir", "WindGustSpeed", "WindDir9am", "WindDir3pm", "WindSpeed9am", "WindSpeed3pm", "Humidity9am", "Humidity3pm", "Pressure9am", "Pressure3pm", "Cloud9am", "Cloud3pm", "Temp9am", "Temp3pm", "RainToday", "RainTomorrow" };

        for (int i = 0; i < data[0].Length; i++)
        {
            if (structure[i] != data[0][i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Splits an array of strings into a jagged array
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private static string[][] DivideData(string[] data)
    {
        char[] charSeparators = new char[] { ',', ';' };
        string[][] newData = new string[data.Length][];

        for (int i = 0; i < data.Length; i++)
        {
            newData[i] = data[i].Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
        }

        return newData;
    }

    /// <summary>
    /// Returns the path entered by the user
    /// </summary>
    /// <returns></returns>
    private static string InputPath()
    {
        Console.Write("Введите путь к файлу: ");
        string path = Console.ReadLine();
        return path;
    }
}
