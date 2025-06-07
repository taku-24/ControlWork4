namespace ex3;

public class CatComparer : IComparer<Cat>
{
    public int Compare(Cat x, Cat y)
    {
        return y.AverageLife.CompareTo(x.AverageLife);
    }
}