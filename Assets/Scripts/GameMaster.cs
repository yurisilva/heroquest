using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    
    public Dice dice;
    public Table table;

    GameObject playingHero;
    float moveSpeed = 6.0f;

    void Start()
    {
        InitializeBoard();
        SetFirstRound();
    }

    public void MoveHero()
    {
        var housesToMove = dice.diceResult;

        while (housesToMove != 0)
        {
            playingHero.GetComponent<Hero>().Move(moveSpeed, table.GetHouse(playingHero.GetComponent<Hero>().houseIndex).nextHouse);

            housesToMove--;
        }

        TogglePlayer();
    }

    private void TogglePlayer()
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

    private void InitializeBoard()
    {
        table = new Table();
    }

    private void SetFirstRound()
    {
        playingHero = red;

        red.GetComponent<Hero>().nextHouse = table.GetHouse(1);
        blue.GetComponent<Hero>().nextHouse = table.GetHouse(15);

        table.GetHouse(1).SetPlayerOccupyingHouse(red);
        table.GetHouse(15).SetPlayerOccupyingHouse(blue);
    }
}