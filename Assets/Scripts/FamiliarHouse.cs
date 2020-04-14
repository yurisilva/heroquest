using UnityEngine;

public class FamiliarHouse : MonoBehaviour
{
    public int module;
    public int uniqueIndex;
    public Vector3 FamiliarPositionInThisHouse()
    {
        return new Vector3(transform.position.x, transform.position.y + 1.56f, transform.position.z);
    }
}
