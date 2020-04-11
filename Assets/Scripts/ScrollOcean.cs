using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollOcean : MonoBehaviour
{
    public float ScrollX = 0.02f;
    public float ScrollY = 0.02f;

    // Update is called once per frame
    void Update()
    {
        float offsetX = Time.time * ScrollX;
        float offsetY = Time.time * ScrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
