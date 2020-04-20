using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class QuestionHelper
{
    private static string[] questionsByLine;

    internal static void AssignQuestionsToHouses(TextAsset textFile)
    {
        questionsByLine = textFile.text.Split('\n');
        List<Question> questions = CreateListOfQuestions();

        for (int i = 0; i < 28; i++)
        {
            Table.HeroHouses[i].question = questions[i];
        }
    }

    private static List<Question> CreateListOfQuestions()
    {
        var questions = new List<Question>();

        foreach (var line in questionsByLine)
        {
            var lineSplit = line.Split(',');

            List<Answer> answers = new List<Answer>();
            answers.Add(new Answer(lineSplit[1], true));
            answers.Add(new Answer(lineSplit[2]));
            answers.Add(new Answer(lineSplit[3]));
            answers.Add(new Answer(lineSplit[4]));

            answers = answers.OrderBy(x => Random.value).ToList();

            questions.Add(new Question(lineSplit[0], answers));
        }

        return questions;
    }
}
