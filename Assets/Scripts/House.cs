using UnityEngine;

public class House
{
    public Transform transform;
    public Transform heroTransformInThisHouse;

    public House(Transform transform)
    {
        this.transform = transform;
    }

    public Transform HeroTransformInThisHouse()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 2.4f, transform.position.z);
        Transform heroTransform = transform;
        heroTransform.position = pos;
        return heroTransform;
    }


}