using UnityEngine;
using UnityEngine.UI;

public class RollDice : MonoBehaviour
{
   public GameObject dice;

   public void GetResult()
    {
        dice.SetActive(true);
        Text diceResultLabel = GameObject.Find("DiceResult").GetComponent<Text>();
        diceResultLabel.text = new System.Random().Next(1, 7).ToString();

    }
}