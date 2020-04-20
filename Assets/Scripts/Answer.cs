public class Answer
{
    public string text;
    public bool isRightAnswer;

    public Answer(string text, bool isRightAnswer = false)
    {
        this.isRightAnswer = isRightAnswer;
        this.text = text;
    }
}