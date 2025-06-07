namespace ex3;

class MiddleCatState : ICatState
{
    public void Increase(ref int value) => value = Math.Min(100, value + 5);
    public void Decrease(ref int value) => value = Math.Max(0, value - 5);
}