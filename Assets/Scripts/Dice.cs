
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public GameObject dice;
    public int diceResult;

    public void RollDice()
    {
        dice.SetActive(true);
        diceResult = new System.Random().Next(1, 7);

        Text diceResultLabel = GameObject.Find("DiceResult").GetComponent<Text>();
        diceResultLabel.text = diceResult.ToString();
    }
}
