using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeBoard : MonoBehaviour
{
    public Table table;

    void Start()
    {
        table = new Table();
        for (int i = 1; i < 29; i++)
        {
            Vector3 vec = table.HeroHouses[i - 1].transform.position;
            Debug.Log(" x:" + vec.x + " y:"+ vec.y+ " z:"+ vec.z);
        }
        Debug.Log(table.HeroHouses.Length);
    }
}
