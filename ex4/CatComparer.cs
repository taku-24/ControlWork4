namespace ex4;

public class CatComparer : IComparer<Cat>
{
    public int Compare(Cat x, Cat y) => y.AverageLife.CompareTo(x.AverageLife);
}