
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public GameObject dice;
    public int diceResult;
    public Text prompt;

    private int i = 0;
    private int[] list = new int[5] { 6,6,1,6,1 };

    public void RollDice()
    {
        dice.SetActive(true);
        diceResult = new System.Random().Next(1, 7);
        prompt.text = diceResult.ToString();

        //Comment the line above and uncomment the next ones to test heroes being hit by familiars and losing points later on
        //diceResult = list[i];
        //i++;

    }
}
