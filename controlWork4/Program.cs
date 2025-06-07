namespace controlWork4;

class Program
{
    static List<Cat> cats = new List<Cat>();
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== КОТЫ ===");
            ShowCats();

            Console.WriteLine("\n1. Добавить нового кота");
            Console.WriteLine("2. Выход");
            Console.Write("Выбор: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddCat();
                    break;
                case "2":
                    return;
                default:
                    Console.WriteLine("Неверный ввод. Нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ShowCats()
    {
        if (cats.Count == 0)
        {
            Console.WriteLine("Котов нет.");
            return;
        }

        cats.Sort(new CatComparer());
        Console.WriteLine($"{"Имя",-10} | {"Возраст",-7} | {"Сытость",-7} | {"Настрой",-7} | {"Здоровье",-9} | {"Ср. уровень"}");
        Console.WriteLine(new string('-', 65));
        foreach (var cat in cats)
        {
            cat.Display();
        }
    }

    static void AddCat()
    {
        Console.Write("Введите имя кота: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Имя не может быть пустым.");
            Pause();
            return;
        }

        Console.Write("Введите возраст кота (целое число): ");
        if (!int.TryParse(Console.ReadLine(), out int age) || age < 0)
        {
            Console.WriteLine("Ошибка: возраст должен быть положительным числом.");
            Pause();
            return;
        }

        cats.Add(new Cat(name, age));
        Console.WriteLine("Кот добавлен!");
        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }
}
