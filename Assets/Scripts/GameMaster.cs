using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    
    public Dice dice;
    public Table table;

    GameObject playingHero;
    Transform currentTransform;
    Vector3 newPosition;
    float moveSpeed = 6.0f;

    bool willMove = false;
    bool debug = true;

    void Start()
    {
        InitializeBoard();
        SetFirstRound();
    }

    private void Update()
    {
        //move this to Hero class.
        if (willMove)
        { 
            playingHero.transform.position = Vector3.MoveTowards(currentTransform.position, newPosition, moveSpeed * Time.deltaTime);
        }

        if(Vector3.Distance(playingHero.transform.position, newPosition) == 0)
        {
            TogglePlayer();
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

        table.SetPlayeOccupyingHouse(1, red);
        table.SetPlayeOccupyingHouse(15, blue);
    }

    public void MoveHero()
    {
        var nextHouseDistance = 4;
        currentTransform = playingHero.transform;

        if (playingHero.name == blue.name)
        {
            newPosition = new Vector3(currentTransform.position.x, currentTransform.position.y, currentTransform.position.z - (nextHouseDistance * dice.diceResult));
        }
        else
        {
            newPosition = new Vector3(currentTransform.position.x, currentTransform.position.y, currentTransform.position.z + (nextHouseDistance * dice.diceResult));
        }

        willMove = true;
    }

    private void TogglePlayer()
    {
        willMove = false;
        if (playingHero.name == red.name)
        {
            playingHero = GetPlayingCharacter(blue.name);
        }
        else
        {
            playingHero = GetPlayingCharacter(red.name);
        }
    }
}