using UnityEngine;

public class Hero : MonoBehaviour
{
    public GameObject familiar;
    public House nextHouse;
    public string houseName;
    public int houseIndex;

    private float moveSpeed;
    private int housesToMove;
    private bool heroWillMove = false;

    public void Move(float moveSpeed, int housesToMove)
    {
        this.housesToMove = housesToMove;
        this.moveSpeed = moveSpeed;
        nextHouse = Table.GetHouse(gameObject.GetComponent<Hero>().houseIndex).nextHouse;
        heroWillMove = housesToMove > 0;
    }

    void Update()
    {
        if (heroWillMove)
        {
            transform.LookAt(nextHouse.HeroPositionInThisHouse());
            transform.position = Vector3.MoveTowards(transform.position, nextHouse.GetComponent<House>().HeroPositionInThisHouse(), moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, nextHouse.HeroPositionInThisHouse()) == 0 && housesToMove > 0)
            {
                housesToMove--;
                nextHouse.SetPlayerOccupyingHouse(gameObject);
                Move(moveSpeed, housesToMove);
            }

        }
    }
}
