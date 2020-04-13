using System;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    
    public Dice dice;
    public Table table;

    string playingHeroName;
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
        if (willMove)
        {
            if (ThereIsACornerOnTheWay())
            {
               
            }
            else
            {
                GameObject hero = GameObject.Find(playingHeroName);
                hero.transform.position = Vector3.MoveTowards(currentTransform.position, newPosition, moveSpeed * Time.deltaTime);
            }
            
        }

        if(Vector3.Distance(GameObject.Find(playingHeroName).transform.position, newPosition) == 0)
        {
            TogglePlayer();
        }
    }

    private bool ThereIsACornerOnTheWay()
    {
        var heroPosition = GameObject.Find(playingHeroName).GetComponent<Hero>();
        if ((heroPosition.houseIndex < 8 && heroPosition.houseIndex + dice.diceResult > 8)
            || (heroPosition.houseIndex < 15 && heroPosition.houseIndex + dice.diceResult > 15)
            || (heroPosition.houseIndex < 22 && heroPosition.houseIndex + dice.diceResult > 22)
            || (heroPosition.houseIndex < 28 && heroPosition.houseIndex + dice.diceResult > 29))
        {
            return true;
        }
        return false;
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