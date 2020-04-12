using UnityEngine;
using UnityEngine.UI;

public class RollDice : MonoBehaviour
{
    public GameObject dice;
    Transform redTransform;
    Vector3 newRedPosition;

    public void GetResult()
    {
        dice.SetActive(true);
        Text diceResultLabel = GameObject.Find("DiceResult").GetComponent<Text>();
        int diceResult = new System.Random().Next(1, 7);

        diceResultLabel.text = diceResult.ToString();

        redTransform = GameObject.Find("RedHero").transform;
        newRedPosition = new Vector3(redTransform.position.x, redTransform.position.y, redTransform.position.z + (4 * diceResult));
    }

    private void Update()
    {
        GameObject.Find("RedHero").transform.position = Vector3.Lerp(redTransform.position, newRedPosition, (0.8f)*Time.deltaTime);
    }
}