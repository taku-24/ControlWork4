namespace controlWork4;

class Cat
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Satiety { get; set; }
    public int Mood { get; set; }
    public int Health { get; set; }

    public double AverageLifeLevel => (Satiety + Mood + Health) / 3.0;

    public Cat(string name, int age)
    {
        Name = name;
        Age = age;
        Satiety = 10;
        Mood = 10;
        Health = 10;
    }

    public void Display()
    {
        Console.WriteLine($"{Name,-10} |     {Age,-3} | {Satiety,-7} | {Mood,-7} | {Health,-7}   | {AverageLifeLevel:F2}");
    }
}

