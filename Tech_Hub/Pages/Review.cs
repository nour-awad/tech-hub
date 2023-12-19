public class Review
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public DateTime now = DateTime.Now;
}

public class StarCalculator
{
    public int CalculateStar1<T>(List<T> list) where T : Review
    {
        return CalculateStarCount(list, 1);
    }

    public int CalculateStar2<T>(List<T> list) where T : Review
    {
        return CalculateStarCount(list, 2);
    }

    public int CalculateStar3<T>(List<T> list) where T : Review
    {
        return CalculateStarCount(list, 3);
    }

    public int CalculateStar4<T>(List<T> list) where T : Review
    {
        return CalculateStarCount(list, 4);
    }

    public int CalculateStar5<T>(List<T> list) where T : Review
    {
        return CalculateStarCount(list, 5);
    }

    private int CalculateStarCount<T>(List<T> list, int starRating) where T : Review
    {
        int count = 0;

        foreach (T item in list)
        {
            if (item.Rating == starRating)
            {
                count++;
            }
        }

        return count;
    }
}
