using System.Collections.Generic;

public class Question
{
    public string prompt;
    public List<Answer> answers;

    public Question(string prompt, List<Answer> answers)
    {
        this.prompt = prompt;
        this.answers = answers;
    }
}
