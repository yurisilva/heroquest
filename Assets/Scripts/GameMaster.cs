using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public GameObject dice;
    public Table table;

    Transform redTransform;
    Vector3 newRedPosition;
    bool willMove = false;
    public float moveSpeed = 6.0f;

    private void Update()
    {
        if (willMove)
        {
            GameObject.Find("RedHero").transform.position = Vector3.MoveTowards(redTransform.position, newRedPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void MoveHero(int diceResult)
    {
        redTransform = GameObject.Find("RedHero").transform;
        newRedPosition = new Vector3(redTransform.position.x, redTransform.position.y, redTransform.position.z + (4 * diceResult));

        willMove = true;
    }

    public void RollDice()
    {
        dice.SetActive(true);
        Text diceResultLabel = GameObject.Find("DiceResult").GetComponent<Text>();
        int diceResult = new System.Random().Next(1, 7);

        diceResultLabel.text = diceResult.ToString();

        MoveHero(diceResult);
    }
}