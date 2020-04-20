using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject redScoreLabel;
    public GameObject blueScoreLabel;
    public GameObject red;
    public GameObject blue;

    void Update()
    {
        redScoreLabel.GetComponentInChildren<Text>().text = red.GetComponent<Hero>().score.ToString();
        blueScoreLabel.GetComponentInChildren<Text>().text = blue.GetComponent<Hero>().score.ToString();
    }
}
