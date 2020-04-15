using System;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public string houseName;
    public int houseIndex;
    public float moveSpeed;
    public GameObject familiar;

    private int housesToMove;
    private bool willMove = false;
    public House nextHouse;

    public void Move(float moveSpeed, House houseToMoveTo)
    {
        this.moveSpeed = moveSpeed;
        willMove = true;
        nextHouse = houseToMoveTo;
        nextHouse.SetPlayerOccupyingHouse(nextHouse.indexOneBased, gameObject);

    }

    public void Move(float moveSpeed, int housesToMove)
    {
        this.housesToMove = housesToMove;
        this.moveSpeed = moveSpeed;
        willMove = true;
        nextHouse = Table.GetHouse(gameObject.GetComponent<Hero>().houseIndex).nextHouse;
    }

    //todo fix: first movement is 
    void Update()
    {
        if (willMove)
        {
            transform.LookAt(nextHouse.HeroPositionInThisHouse());
            transform.position = Vector3.MoveTowards(transform.position, nextHouse.GetComponent<House>().HeroPositionInThisHouse(), moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, nextHouse.HeroPositionInThisHouse()) == 0 && housesToMove > 0)
            {
                housesToMove--;
                nextHouse.SetPlayerOccupyingHouse(gameObject);
                Move(moveSpeed, housesToMove);
            }
            else if (Vector3.Distance(transform.position, nextHouse.HeroPositionInThisHouse()) == 0 && housesToMove == 0)
            {
                willMove = false;
            }

        }
    }
}
