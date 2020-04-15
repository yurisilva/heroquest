using UnityEngine;

public class FamiliarHouse : MonoBehaviour
{
    public int module;
    public int uniqueIndex;
    public FamiliarHouse opposingHouse;

    public Vector3 FamiliarPositionInThisHouse()
    {
        return new Vector3(transform.position.x, transform.position.y + 1.58f, transform.position.z);
    }
}
