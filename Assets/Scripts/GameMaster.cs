using System;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    public GameObject playingHero;
    public Dice dice;
    public Table table;

    public int expo;

    Transform currentTransform;
    Vector3 newTransformPosition;
    bool willMove = false;
    public float moveSpeed = 6.0f;

    private bool debug = false;

    void Start()
    {
        InitializeBoard();
        playingHero = red;
    }

    private void Update()
    {
        if (willMove)
        {
            playingHero.transform.position = Vector3.MoveTowards(currentTransform.position, newTransformPosition, moveSpeed * Time.deltaTime);
        }

        if(playingHero.transform.position == newTransformPosition)
        {
            TogglePlayer();
        }
    }

    private void InitializeBoard()
    {
        table = new Table();
        for (int i = 1; i < 29; i++)
        {
            Vector3 vec = table.HeroHouses[i - 1].transform.position;
            if (debug) Debug.Log(" x:" + vec.x + " y:" + vec.y + " z:" + vec.z);
        }
    }

    public void MoveHero()
    {
        var nextHouseDistance = 4;
        currentTransform = playingHero.transform;
        newTransformPosition = new Vector3(currentTransform.position.x, currentTransform.position.y, currentTransform.position.z + (nextHouseDistance * dice.diceResult));

        willMove = true;
    }

    private void TogglePlayer()
    {
        if (playingHero.name == "RedHero")
        {
            playingHero = blue;
        }
        else
        {
            playingHero = red;
        }
    }
}