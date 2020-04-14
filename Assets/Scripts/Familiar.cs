using UnityEngine;

public class Familiar : MonoBehaviour
{
    public int houseModule;
    public GameObject opposingFamiliar;

    public float moveSpeed;
    public bool willMove = false;
    public FamiliarHouse houseToMoveTo;

    public void Move(float moveSpeed, int diceResult)
    {
        this.moveSpeed = moveSpeed;
        willMove = true;
        var familiarHouseName = gameObject.name == "RedFamiliar" ? "FR" : "FB";
        houseToMoveTo = Table.GetFamiliarHouseByName(familiarHouseName + diceResult.ToString());
    }

    void Update()
    {
        if (willMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, houseToMoveTo.GetComponent<FamiliarHouse>().FamiliarPositionInThisHouse(), moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, houseToMoveTo.GetComponent<FamiliarHouse>().FamiliarPositionInThisHouse()) == 0)
            {
                willMove = false;
            }

        }
    }
}