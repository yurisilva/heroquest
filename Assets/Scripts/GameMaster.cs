using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    
    public Dice dice;

    GameObject playingHero;
    float moveSpeed = 6.0f;

    void Start()
    {
        Table.InitializeTable();
        PlacePiecesOnTheBoard();
    }

    public void MoveHero()
    {
        var housesToMove = dice.diceResult;

        while (housesToMove != 0)
        {
            playingHero.GetComponent<Hero>().GetComponent<Hero>().Move(moveSpeed, Table.GetHouse(playingHero.GetComponent<Hero>().houseIndex).nextHouse);
            housesToMove--;
        }
    }

    public void MoveFamiliar()
    {
        playingHero.GetComponent<Hero>().familiar.GetComponent<Familiar>().Move(moveSpeed, dice.diceResult);
    }

    public void TogglePlayer()
    {
        if (playingHero.name == red.name)
        {
            playingHero = GetPlayingCharacter(blue.name);
        }
        else
        {
            playingHero = GetPlayingCharacter(red.name);
        }
    }

    private GameObject GetPlayingCharacter(string name)
    {
        return name == red.name ? red : blue;
    }

    private void PlacePiecesOnTheBoard()
    {
        playingHero = red;

        red.GetComponent<Hero>().nextHouse = Table.GetHouse(1);
        blue.GetComponent<Hero>().nextHouse = Table.GetHouse(15);

        Table.GetHouse(1).SetPlayerOccupyingHouse(red);
        Table.GetHouse(15).SetPlayerOccupyingHouse(blue);

        red.GetComponent<Hero>().familiar.transform.position = Table.GetFamiliarHouse(1).FamiliarPositionInThisHouse();
        red.GetComponent<Hero>().familiar.GetComponent<Familiar>().houseModule = 1;

        blue.GetComponent<Hero>().familiar.transform.position = Table.GetFamiliarHouse(7).FamiliarPositionInThisHouse();
        blue.GetComponent<Hero>().familiar.GetComponent<Familiar>().houseModule = 7;
    }
}