using System;
using UnityEngine;

public static class Table
{
    public static House[] HeroHouses;
    public static FamiliarHouse[] FamiliarHouses;
    public static bool heroMoving = false;
    public static bool familiarMoving = false;

    public static void InitializeTable()
    {
        InitializeHeroHouses();
        InitializeFamiliarHouses();
    }

    public static Question GetHouseQuestion(int indexOneBased)
    {
        return GetHouse(indexOneBased).GetComponent<House>().question;
    }

    private static void InitializeFamiliarHouses()
    {
        FamiliarHouses = new FamiliarHouse[12];
        var blueUniqueIndex = 12;
        for (int i = 1; i < 7; i++)
        {
            var houseRed = GameObject.Find("FR" + i.ToString()).GetComponent<FamiliarHouse>();
            var houseBlue = GameObject.Find("FB" + i.ToString()).GetComponent<FamiliarHouse>();

            houseRed.module = i;
            houseBlue.module = i;

            houseRed.uniqueIndex = i;
            houseBlue.uniqueIndex = blueUniqueIndex;
            blueUniqueIndex--;

            FamiliarHouses[i - 1] = houseRed;
            FamiliarHouses[i + 6 - 1] = houseBlue;
        }

        SetOpposingHouses();
    }

    private static void SetOpposingHouses()
    {
        var upperHouses = 11;
        for (int i = 0; i < 6; i++)
        {
            FamiliarHouses[i].opposingHouse = FamiliarHouses[upperHouses];
            FamiliarHouses[upperHouses].opposingHouse = FamiliarHouses[i];
            upperHouses--;
        }
    }

    private static void InitializeHeroHouses()
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

    public static FamiliarHouse GetFamiliarHouseByName(string houseName)
    {
        foreach (var house in FamiliarHouses)
        {
            if (house.name == houseName)
            {
                return house;
            }
        }
        throw new Exception("Familiar house does not exist.");
    }

    public static House GetHouse(int indexOneBased)
    {
        return HeroHouses[indexOneBased - 1];
    }

    public static FamiliarHouse GetFamiliarHouse(int indexOneBased)
    {
        foreach (var house in FamiliarHouses)
        {
            if (house.uniqueIndex == indexOneBased)
            {
                return house;
            }
        }
        throw new Exception("Familiar house does not exist.");
    }
}
