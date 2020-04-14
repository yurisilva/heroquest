using UnityEngine;

public class Hero : MonoBehaviour
{
    public string houseName;
    public int houseIndex;
    public float moveSpeed;
    public GameObject familiar;

    private bool willMove = false;
    public House nextHouse;

    public void Move(float moveSpeed, House houseToMoveTo)
    {
        this.moveSpeed = moveSpeed;
        willMove = true;
        nextHouse = houseToMoveTo;
        nextHouse.SetPlayerOccupyingHouse(nextHouse.indexOneBased, gameObject);

    }

    private void Update()
    {
        if (willMove)
        {
            transform.LookAt(nextHouse.HeroPositionInThisHouse());
            transform.position = Vector3.MoveTowards(transform.position, nextHouse.GetComponent<House>().HeroPositionInThisHouse(), moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, nextHouse.HeroPositionInThisHouse()) == 0)
            {
                willMove = false;
            }
        }
    }
}
