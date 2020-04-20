using UnityEngine;

public class QuestionCanvas : MonoBehaviour
{
    public GameObject questionOutput;
    public GameObject Answer1Output;
    public GameObject Answer2Output;
    public GameObject Answer3Output;
    public GameObject Answer4Output;
    public bool turnIsOver = false;
    public AnswerEnum gotAnswerRight = AnswerEnum.NOT_ANSWERED_YET;
}
