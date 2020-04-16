using UnityEngine;

public class Familiar : MonoBehaviour
{
    public GameObject opposingFamiliar;
    public float moveSpeed;
    public int houseUniqueIndex;
    public FamiliarHouse houseToMoveTo;

    private Vector3 posLastFrame = new Vector3(0,0,0);
    public bool familiarWillMove = false;

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

            if (transform.position == posLastFrame)
            {
                familiarWillMove = false;
            }

        }
        posLastFrame = transform.position;
    }
}