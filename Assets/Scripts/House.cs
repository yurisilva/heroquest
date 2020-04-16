using UnityEngine;

public class House : MonoBehaviour
{
    public int indexOneBased;
    public House nextHouse;
    public int familiarHouseUniqueIndex;
    public Question question;

    public House(int index, House nextHouse)
    {
        indexOneBased = index;
        this.nextHouse = nextHouse;
    }

    public void SetPlayerOccupyingHouse(GameObject player)
    {
        player.GetComponent<Hero>().houseIndex = indexOneBased;
        player.GetComponent<Hero>().houseName = "H" + indexOneBased.ToString();
        player.transform.forward = GetFacingDirection();
        player.transform.position = HeroPositionInThisHouse();
    }

    public void SetPlayerOccupyingHouse(int indexOneBased, GameObject player)
    {
        player.GetComponent<Hero>().houseIndex = indexOneBased;
        player.GetComponent<Hero>().houseName = "H" + indexOneBased.ToString();
        player.transform.forward = GetFacingDirection();
        player.transform.position = HeroPositionInThisHouse();
    }

    public Vector3 HeroPositionInThisHouse()
    {
        return new Vector3(transform.position.x, transform.position.y + 2.4f, transform.position.z);
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