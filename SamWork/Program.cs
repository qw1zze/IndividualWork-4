public partial class Program
{

    /// <summary>
    /// Choose command
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private static bool ChooseCommand(ref string[][] data)
    {
        //Вывод Меню
        Console.WriteLine("Нажмите 1, чтобы ввести адрес файла");
        Console.WriteLine("Нажмите 2, чтобы вывести информацию о Сиднее");
        Console.WriteLine("Нажмите 3, чтобы вывести набор данных по локациям");
        Console.WriteLine("Нажмите 4, чтобы вывести информацию о солнечной погоде");
        Console.WriteLine("Нажмите 5, чтобы вывести сводную статистику");
        Console.Write("Выберете команду, или нажмите Q, для выхода из программы: ");

        //Проверка номера команды
        var key = Console.ReadKey().Key;
        Console.WriteLine();

        switch (key)
        {
            case ConsoleKey.D1:
                ChangeData(ref data);
                break;

            case ConsoleKey.D2:
                string[] table = GetTableForSydney(data);
                PrintTable(table);
                SaveInformation(table, "Sydney_2009_2010_weatherAUS.csv");
                break;

            case ConsoleKey.D3:
                PrintGroups(data);
                break;

            case ConsoleKey.D4:
                string[] tb = GetTableForSunshine(data);
                PrintTable(tb);
                InputSaveFile(tb);
                break;

            case ConsoleKey.D5:
                Console.Write("Количество дней пригодных для рыбалки: ");
                Console.WriteLine(CountDaysFish(data));
                GetGroups(data);
                Console.Write("Количество теплых дождливых дней: ");
                Console.WriteLine(CountDaysFishSun(data));
                Console.Write("Количество дней с нормальным атмосферным давлением: ");
                Console.WriteLine(CountDaysPressure(data));
                Console.WriteLine();
                break;

            case ConsoleKey.Q:
                return false;
                break;

            default:
                Console.WriteLine("Неизвестная команда.");
                break;
        }

        return true;

    }

    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

        //Checking for the possibility of opening the default file
        string[][] mainData;
        try
        {
            mainData = DivideData(File.ReadAllLines("weatherAUS.csv"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Неизветсная ошибка открытия файла по умолчанию! Проверьте, что файл не используется.");
            return;
        }

        Console.WriteLine("Добро пожаловать!");

        while (ChooseCommand(ref mainData))
        {

        }
    }
}