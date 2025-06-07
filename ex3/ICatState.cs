namespace ex3;

public interface ICatState
{
    void Increase(ref int value);
    void Decrease(ref int value);
}