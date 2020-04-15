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
        playingHero.GetComponent<Hero>().GetComponent<Hero>().Move(moveSpeed, dice.diceResult);
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

        Table.GetHouse(1).SetPlayerOccupyingHouse(red);
        Table.GetHouse(15).SetPlayerOccupyingHouse(blue);

        red.GetComponent<Hero>().nextHouse = Table.GetHouse(2);
        blue.GetComponent<Hero>().nextHouse = Table.GetHouse(16);

        red.GetComponent<Hero>().familiar.transform.position = Table.GetFamiliarHouse(1).FamiliarPositionInThisHouse();
        red.GetComponent<Hero>().familiar.GetComponent<Familiar>().houseUniqueIndex = Table.GetFamiliarHouse(1).GetComponent<FamiliarHouse>().uniqueIndex;

        blue.GetComponent<Hero>().familiar.transform.position = Table.GetFamiliarHouse(1).opposingHouse.FamiliarPositionInThisHouse();
        blue.GetComponent<Hero>().familiar.GetComponent<Familiar>().houseUniqueIndex = Table.GetFamiliarHouse(1).opposingHouse.GetComponent<FamiliarHouse>().uniqueIndex;
    }
}