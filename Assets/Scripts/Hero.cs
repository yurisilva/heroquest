using UnityEngine;

public class Hero : MonoBehaviour
{
    public GameObject familiar;
    public House nextHouse;
    public string houseName;
    public int houseIndex;

    public bool requestsCamera = false;
    public bool hasMessage = false;
    public string message = "";

    private float moveSpeed;
    private int housesToMove;
    private bool heroWillMove = false;

    public void Move(float moveSpeed, int housesToMove)
    {
        this.housesToMove = housesToMove;
        this.moveSpeed = moveSpeed;
        nextHouse = Table.GetHouse(gameObject.GetComponent<Hero>().houseIndex).nextHouse;
        heroWillMove = housesToMove > 0;

        if (housesToMove == 0 && familiar.GetComponent<Familiar>().familiarWillMove == false) 
        {
            CheckForEnemyFamiliar();
            GetQuestion(houseIndex);
            requestsCamera = true;
        }
    }

    private void GetQuestion(int houseIndex)
    {
        Table.GetHouseQuestion(houseIndex);
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

    public void CheckForEnemyFamiliar()
    {
        var houseZone = Table.GetHouse(houseIndex).GetComponent<House>().familiarHouseUniqueIndex;
        var enemyFamiliarHouseZone = familiar.GetComponent<Familiar>().opposingFamiliar.GetComponent<Familiar>().houseUniqueIndex;

        if (houseZone == enemyFamiliarHouseZone) 
        {
            hasMessage = true;
            message ="Your hero landed in the enemy's familiar zone. You got attacked.";
        }
    }
}
