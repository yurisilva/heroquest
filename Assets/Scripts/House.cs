using UnityEngine;

public class House
{
    public Transform transform;
    public int indexOneBased;
    //public Question question; //future stuff

    public House(int index, Transform transform)
    {
        this.transform = transform;
        this.indexOneBased = index;
    }

    public Vector3 HeroPositionInThisHouse()
    {
        return new Vector3(this.transform.position.x, this.transform.position.y + 2.4f, this.transform.position.z);
    }

    public Vector3 GetFacingDirection()
    {
        Vector3 forward = new Vector3(0, 0, 1);
        
        if(indexOneBased > 0 && indexOneBased < 8)
        {
            forward = new Vector3(0, 0, 1);
        } 
        if (indexOneBased > 7 && indexOneBased < 15)
        {
            forward = new Vector3(1, 0, 0);
        }
        if (indexOneBased > 14 && indexOneBased < 22)
        {
            forward = new Vector3(0, 0, -1);
        }
        if (indexOneBased > 21 && indexOneBased < 29)
        {
            forward = new Vector3(-1, 0, 0);
        }

        return forward;
    }
}