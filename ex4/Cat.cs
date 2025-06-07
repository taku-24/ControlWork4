namespace ex4;

 public class Cat
    {
        public string Name { get; set; }
        public int Age { get; set; }

        private int _satiety;
        private int _mood;
        private int _health;

        private ICatState _state;
        private Random _rnd = new Random();

        public int Satiety => _satiety;
        public int Mood => _mood;
        public int Health => _health;
        public double AverageLife => (_satiety + _mood + _health) / 3.0;

        public event Action<Cat> OnMaxSatiety;
        public event Action<Cat> OnMaxMood;
        public event Action<Cat> OnMaxHealth;

        public Cat(string name, int age)
        {
            Name = name;
            Age = age;
            _satiety = 10;
            _mood = 10;
            _health = 10;
            SetState();
        }

        private void SetState()
        {
            if (Age <= 5) _state = new YoungCatState();
            else if (Age <= 10) _state = new MiddleCatState();
            else _state = new OldCatState();
        }

        public void Feed()
        {
            if (_rnd.Next(1, 101) <= 15)
            {
                Console.WriteLine("Кот отравился!");
                _mood = Math.Max(0, _mood - 15);
                _health = Math.Max(0, _health - 20);
            }
            else
            {
                _state.Increase(ref _satiety);
                _state.Increase(ref _mood);
                if (_satiety == 100) OnMaxSatiety?.Invoke(this);
                Console.WriteLine("Кот поел.");
            }
        }

        public void Play()
        {
            if (_rnd.Next(1, 101) <= 15)
            {
                Console.WriteLine("Кот травмировался!");
                _mood = Math.Max(0, _mood - 20);
                _health = Math.Max(0, _health - 15);
            }
            else
            {
                _state.Decrease(ref _satiety);
                _state.Increase(ref _mood);
                if (_mood == 100) OnMaxMood?.Invoke(this);
                Console.WriteLine("Кот поиграл.");
            }
        }

        public void Heal()
        {
            if (_rnd.Next(1, 101) <= 10)
            {
                Console.WriteLine("Лечение вызвало стресс!");
                _mood = Math.Max(0, _mood - 15);
                _satiety = Math.Max(0, _satiety - 10);
            }
            else
            {
                _state.Decrease(ref _satiety);
                _state.Decrease(ref _mood);
                _state.Increase(ref _health);
                if (_health == 100) OnMaxHealth?.Invoke(this);
                Console.WriteLine("Кот полечился.");
            }
        }

        public bool IsDead() => _satiety <= 0 || _mood <= 0 || _health <= 0;
        public bool IsOverdue() => _satiety <= 3 || _mood <= 3 || _health <= 3;
    }