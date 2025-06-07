namespace controlWork4;

class CatComparer : IComparer<Cat>
{
    public int Compare(Cat x, Cat y)
    {
        return y.AverageLifeLevel.CompareTo(x.AverageLifeLevel);
    }
}


