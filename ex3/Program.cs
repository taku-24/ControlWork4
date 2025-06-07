using System.Text.Json;
namespace ex3;
class Program
{
    static List<Cat> cats = new List<Cat>();
    static string fileName = "cats.json";
    static event Action<Cat> CatDied;

    static void Main()
    {
        LoadCatsFromFile();
        CatDied += cat =>
        {
            Console.WriteLine($"Кот {cat.Name} умер...");
            cats.Remove(cat);
            SaveCatsToFile();
        };

        while (true)
        {
            Console.Clear();
            ShowCats();
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добавить кота");
            Console.WriteLine("2. Взаимодействие с котом");
            Console.WriteLine("3. Выход");

            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": AddCat(); break;
                case "2": InteractWithCat(); break;
                case "3": return;
                default: Console.WriteLine("Неверный выбор!"); break;
            }

            Console.WriteLine("Нажмите Enter для продолжения...");
            Console.ReadLine();
        }
    }

    static void AddCat()
    {
        Console.Write("Введите имя кота: ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) { Console.WriteLine("Имя не может быть пустым!"); return; }

        Console.Write("Введите возраст кота: ");
        if (!int.TryParse(Console.ReadLine(), out int age)) { Console.WriteLine("Неверный формат возраста."); return; }

        cats.Add(new Cat(name, age));
        cats.Sort(new CatComparer());
        SaveCatsToFile();
    }

    static void InteractWithCat()
    {
        if (cats.Count == 0) { Console.WriteLine("Котов нет."); return; }

        for (int i = 0; i < cats.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {cats[i].Name}");
        }
        Console.Write("Выберите кота по номеру: ");
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > cats.Count)
        {
            Console.WriteLine("Неверный выбор.");
            return;
        }

        Cat selectedCat = cats[index - 1];

        Console.WriteLine("1. Покормить\n2. Поиграть\n3. Лечить");
        Console.Write("Выберите действие: ");
        string action = Console.ReadLine();

        switch (action)
        {
            case "1": selectedCat.Feed(); break;
            case "2": selectedCat.Play(); break;
            case "3": selectedCat.Heal(); break;
            default: Console.WriteLine("Неверное действие."); return;
        }

        if (selectedCat.IsDead())
        {
            CatDied.Invoke(selectedCat);
        }

        SaveCatsToFile();
    }

    static void ShowCats()
    {
        if (cats.Count == 0)
        {
            Console.WriteLine("Котов пока нет.");
            return;
        }

        Console.WriteLine("Список котов:");
        Console.WriteLine("Имя\tВозраст\tСытость\tНастроение\tЗдоровье\tСредний уровень");

        foreach (var cat in cats.OrderByDescending(c => c.AverageLife))
        {
            Console.ForegroundColor = cat.IsOverdue() ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine($"{cat.Name}\t{cat.Age}\t{cat.Satiety}\t{cat.Mood}\t\t{cat.Health}\t\t{cat.AverageLife:f2}" + (cat.IsOverdue() ? "  [просрочено]" : ""));
        }

        Console.ResetColor();
    }

    static void SaveCatsToFile()
    {
        File.WriteAllText(fileName, JsonSerializer.Serialize(cats));
    }

    static void LoadCatsFromFile()
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("Файл с котами не найден. Добавьте нового кота.");
            return;
        }

        try
        {
            string json = File.ReadAllText(fileName);
            cats = JsonSerializer.Deserialize<List<Cat>>(json);
        }
        catch
        {
            Console.WriteLine("Ошибка чтения файла.");
        }
    }
}

