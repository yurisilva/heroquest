
using UnityEngine;

public class Answer : MonoBehaviour
{
    public string text;
    public bool isRightAnswer;

    public Answer(string text, bool isRightAnswer = false)
    {
        this.isRightAnswer = isRightAnswer;
        this.text = text;
    }
}