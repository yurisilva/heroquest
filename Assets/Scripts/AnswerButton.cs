using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Answer answer;
    public bool isRightAnswer = false;
    private bool endTurn = false;

    void Start()
    {
        gameObject.GetComponent<Button>().GetComponentInChildren<Text>().text = answer.text;
        isRightAnswer = answer.isRightAnswer;
    }

    public void AssignNewAnswer(Answer answer)
    {
        this.answer = answer;
        gameObject.GetComponent<Button>().GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        gameObject.GetComponent<Button>().GetComponentInChildren<Text>().text = answer.text;
        isRightAnswer = answer.isRightAnswer;
    }

    public void CheckAnswer()
    {
        if (isRightAnswer)
        {
            gameObject.GetComponent<Image>().color = new Color32(0, 255, 0, 100); 
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
        }

        endTurn = true;
    }

    void Update()
    {
        if (endTurn)
        {
            endTurn = false;
            StartCoroutine(EndTurn());
        }
    }

    public IEnumerator EndTurn()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponentInParent<QuestionCanvas>().turnIsOver = true;
    }

}
