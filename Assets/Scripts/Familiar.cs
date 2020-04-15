using UnityEngine;

public class Familiar : MonoBehaviour
{
    public GameObject opposingFamiliar;
    public float moveSpeed;
    public int houseUniqueIndex;
    public FamiliarHouse houseToMoveTo;

    private bool familiarWillMove = false;

    public void Move(float moveSpeed, int diceResult)
    {
        this.moveSpeed = moveSpeed;
        var familiarHouseName = gameObject.name == "RedFamiliar" ? "FR" : "FB";
        houseToMoveTo = Table.GetFamiliarHouseByName(familiarHouseName + diceResult.ToString());
        familiarWillMove = true;
    }

    void Update()
    {
        if (familiarWillMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, houseToMoveTo.GetComponent<FamiliarHouse>().FamiliarPositionInThisHouse(), moveSpeed * Time.deltaTime);
            opposingFamiliar.transform.position = Vector3.MoveTowards(opposingFamiliar.transform.position,
                                                                      houseToMoveTo.opposingHouse.FamiliarPositionInThisHouse(),
                                                                      moveSpeed * Time.deltaTime);

            //Debug.Log(Vector3.Distance(transform.position, houseToMoveTo.GetComponent<FamiliarHouse>().FamiliarPositionInThisHouse()));
            //todo ynfs Distance compares world-relative position with Familiar object's relative position, thus movement never ends.
            if (Vector3.Distance(transform.position, houseToMoveTo.GetComponent<FamiliarHouse>().FamiliarPositionInThisHouse()) == 0)
            {
                familiarWillMove = false;
            }
        }
    }
}