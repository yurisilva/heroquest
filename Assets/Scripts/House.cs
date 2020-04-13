using UnityEngine;

public class House
{
    public Transform transform;
    public Transform heroTransformInThisHouse;
    public int indexOneBased;
    public Question question;

    public House(int index, Transform transform)
    {
        this.transform = transform;
        this.indexOneBased = index;
    }

    public Transform HeroTransformInThisHouse()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 2.4f, transform.position.z);
        Transform heroTransform = transform;
        heroTransform.position = pos;
        return heroTransform;
    }


}