using UnityEngine;

public class Table
{
    public House[] HeroHouses;

    public Table()
    {
        HeroHouses = new House[28];
        for (int i = 1; i < 29; i++)
        {
            var nextHouseIndex = i + 1;
            if (i == 28) nextHouseIndex = 1;

            var house = GameObject.Find("H" + i.ToString()).GetComponent<House>();
            house.nextHouse = GameObject.Find("H" + nextHouseIndex.ToString()).GetComponent<House>();
            house.indexOneBased = i;
            HeroHouses[i - 1] = house;
        }
    }

    public House GetHouse(int indexOneBased)
    {
        return HeroHouses[indexOneBased - 1];
    }
}
