﻿using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public string prompt;
    public List<Answer> answers;

    public Question(string prompt, List<Answer> answers)
    {
        this.prompt = prompt;
        this.answers = answers;
    }
}

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