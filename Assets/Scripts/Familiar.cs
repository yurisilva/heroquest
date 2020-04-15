using UnityEngine;

public class Familiar : MonoBehaviour
{
    public int houseModule;
    public GameObject opposingFamiliar;
    public float moveSpeed;
    public bool willMove = false;
    public FamiliarHouse houseToMoveTo;

    private int diceResult;
    private int opposingFamiliarWillMoveTo;

    public void Move(float moveSpeed, int diceResult)
    {
        this.diceResult = diceResult;
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
            opposingFamiliar.transform.position = Vector3.MoveTowards(opposingFamiliar.transform.position,
                                                                      houseToMoveTo.opposingHouse.FamiliarPositionInThisHouse(),
                                                                      moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, houseToMoveTo.GetComponent<FamiliarHouse>().FamiliarPositionInThisHouse()) == 0)
            {
                willMove = false;
            }

        }
    }
}