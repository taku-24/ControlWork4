namespace ex2;

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
            Console.WriteLine("3. Взаимодействовать с котом");
            Console.Write("Выбор: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddCat();
                    break;
                case "2":
                    return;
                case "3":
                    InteractWithCat();
                    break;
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
        Console.WriteLine($"{"Имя"}     | {"Возраст"} | {"Сытость"} | {"Настрой"} | {"Здоровье"} | {"Ср. уровень"}");
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
    static void InteractWithCat()
    {
        if (cats.Count == 0)
        {
            Console.WriteLine("Сначала добавьте кота!");
            Pause();
            return;
        }

        Console.WriteLine("Выберите кота:");
        for (int i = 0; i < cats.Count; i++)
            Console.WriteLine($"{i + 1}. {cats[i].Name}");

        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > cats.Count)
        {
            Console.WriteLine("Неверный выбор.");
            Pause();
            return;
        }

        Cat selectedCat = cats[index - 1];

        Console.WriteLine($"Выбран кот {selectedCat.Name}");
        Console.WriteLine("1. Покормить");
        Console.WriteLine("2. Поиграть");
        Console.WriteLine("3. Полечить");
        Console.Write("Выбор: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                selectedCat.Feed();
                Console.WriteLine("Кот покормлен!");
                break;
            case "2":
                selectedCat.Play();
                Console.WriteLine("Вы поиграли с котом!");
                break;
            case "3":
                selectedCat.Heal();
                Console.WriteLine("Кот вылечен!");
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }

        Pause();
    }


    

    

    
    
}