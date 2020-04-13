using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    public string playingHeroName;
    public Dice dice;
    public Table table;

    public int expo;

    Transform currentTransform;
    Vector3 newTransformPosition;
    bool willMove = false;
    public float moveSpeed = 6.0f;

    private bool debug = true;

    void Start()
    {
        InitializeBoard();
        SetFirstRound();
    }

    private void Update()
    {
        if (willMove)
        {
            GameObject hero = GameObject.Find(playingHeroName);    
            hero.transform.position = Vector3.MoveTowards(currentTransform.position, newTransformPosition, moveSpeed * Time.deltaTime);
        }

        if(Vector3.Distance(GameObject.Find(playingHeroName).transform.position, newTransformPosition) == 0)
        {
            TogglePlayer();
        }
    }

    private void InitializeBoard()
    {
        table = new Table();
    }

    private void SetFirstRound()
    {
        playingHeroName = red.name;

        table.SetPlayeOccupyingHouse(1, red);
        table.SetPlayeOccupyingHouse(15, blue);
    }

    public void MoveHero()
    {
        var nextHouseDistance = 4;
        currentTransform = GameObject.Find(playingHeroName).transform;

        if (playingHeroName == blue.name)
        {
            newTransformPosition = new Vector3(currentTransform.position.x, currentTransform.position.y, currentTransform.position.z - (nextHouseDistance * dice.diceResult));
        }
        else
        {
            newTransformPosition = new Vector3(currentTransform.position.x, currentTransform.position.y, currentTransform.position.z + (nextHouseDistance * dice.diceResult));

            //This is how you change the transform to +x
            //currentTransform.forward = new Vector3(1, 0, 0
        }

        willMove = true;
    }

    private void TogglePlayer()
    {
        willMove = false;
        if (playingHeroName == red.name)
        {
            playingHeroName = blue.name;
        }
        else
        {
            playingHeroName = red.name;
        }
    }
}