namespace ex2;

class CatComparer : IComparer<Cat>
{
    public int Compare(Cat x, Cat y)
    {
        return y.AverageLifeLevel.CompareTo(x.AverageLifeLevel);
    }
}