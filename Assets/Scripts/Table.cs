using UnityEngine;

public class Table
{
    public House[] HeroHouses;

    public Table()
    {
        HeroHouses = new House[28];
        for (int i = 1; i < 29; i++)
        {
            HeroHouses[i - 1] = new House(i, GameObject.Find("H" + i.ToString()).transform);
        }
    }
}
