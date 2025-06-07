namespace ex2;

public class Cat
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Satiety { get; set; }
    public int Mood { get; set; }
    public int Health { get; set; }

    public double AverageLifeLevel => (Satiety + Mood + Health) / 3.0;

    private ICatState _state;

    public Cat(string name, int age)
    {
        Name = name;
        Age = age;
        Satiety = Mood = Health = 10;

        _state = GetState();
    }

    private ICatState GetState()
    {
        if (Age <= 5)
            return new YoungState();
        else if (Age <= 10)
            return new AdultState();
        else
            return new OldState();
    }

    public void Feed()
    {
        Satiety += _state.IncreaseAmount;
        Mood += _state.IncreaseAmount;
    }

    public void Play()
    {
        Satiety = Math.Max(0, Satiety - _state.DecreaseAmount);
        Mood += _state.IncreaseAmount;
    }

    public void Heal()
    {
        Satiety = Math.Max(0, Satiety - _state.DecreaseAmount);
        Mood = Math.Max(0, Mood - _state.DecreaseAmount);
        Health += _state.IncreaseAmount;
    }

    public void Display()
    {
        Console.WriteLine($"{Name}   | {Age}       | {Satiety}      | {Mood}      | {Health}       | {AverageLifeLevel}");
    }
}
