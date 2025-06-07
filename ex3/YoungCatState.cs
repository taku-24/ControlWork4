namespace ex3;

public class YoungCatState : ICatState
{
    public void Increase(ref int value) => value = Math.Min(100, value + 10);
    public void Decrease(ref int value) => value = Math.Max(0, value - 2);
}