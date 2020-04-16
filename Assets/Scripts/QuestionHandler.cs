using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class QuestionHandler
{
    private static string[] questionsByLine;

    internal static void AssignQuestionsToHouses(TextAsset textFile)
    {
        questionsByLine = textFile.text.Split('\n');
        List<Question> questions = CreateListOfQuestions();

        foreach (var house in Table.HeroHouses)
        {
            house.question = questions[new System.Random().Next(0, 2)];
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
