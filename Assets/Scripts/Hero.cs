using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public GameObject familiar;
    public House nextHouse;
    public string houseName;
    public int houseIndex;
    public GameObject questionCanvas;
    public int score;
    public int lastHouseIndex;

    public bool requestsCamera = false;
    public bool hasMessage = false;
    public string message = "";

    private float moveSpeed;
    private int housesToMove;
    private bool heroWillMove = false;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if (heroWillMove)
        {
            transform.LookAt(nextHouse.HeroPositionInThisHouse());
            transform.position = Vector3.MoveTowards(transform.position, nextHouse.GetComponent<House>().HeroPositionInThisHouse(), moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, nextHouse.HeroPositionInThisHouse()) == 0 && housesToMove > 0)
            {
                housesToMove--;
                nextHouse.SetPlayerOccupyingHouse(gameObject);
                Move(moveSpeed, housesToMove);
            }
        }
    }

    public void Move(float moveSpeed, int housesToMove)
    {
        this.housesToMove = housesToMove;
        this.moveSpeed = moveSpeed;
        nextHouse = Table.GetHouse(gameObject.GetComponent<Hero>().houseIndex).nextHouse;
        heroWillMove = housesToMove > 0;

        if (housesToMove == 0 && familiar.GetComponent<Familiar>().familiarWillMove == false) 
        {
            //CheckForEnemyFamiliar();
            LoadQuestionFromHouseIntoQuestionCanvas(houseIndex);
            requestsCamera = true;
        }
    }

    private void LoadQuestionFromHouseIntoQuestionCanvas(int houseIndex)
    {
        Question question = Table.GetHouseQuestion(houseIndex);

        gameObject.GetComponent<Hero>().questionCanvas.GetComponent<QuestionCanvas>().questionOutput.GetComponent<Text>().text = question.prompt;

        gameObject.GetComponent<Hero>().questionCanvas.GetComponent<QuestionCanvas>().Answer1Output.GetComponent<Button>().GetComponent<AnswerButton>().AssignNewAnswer(question.answers[0]);
        gameObject.GetComponent<Hero>().questionCanvas.GetComponent<QuestionCanvas>().Answer2Output.GetComponent<Button>().GetComponent<AnswerButton>().AssignNewAnswer(question.answers[1]);
        gameObject.GetComponent<Hero>().questionCanvas.GetComponent<QuestionCanvas>().Answer3Output.GetComponent<Button>().GetComponent<AnswerButton>().AssignNewAnswer(question.answers[2]);
        gameObject.GetComponent<Hero>().questionCanvas.GetComponent<QuestionCanvas>().Answer4Output.GetComponent<Button>().GetComponent<AnswerButton>().AssignNewAnswer(question.answers[3]);
    }

    public void CheckForEnemyFamiliar()
    {
        var houseZone = Table.GetHouse(houseIndex).GetComponent<House>().familiarHouseUniqueIndex;
        var enemyFamiliarHouseZone = familiar.GetComponent<Familiar>().opposingFamiliar.GetComponent<Familiar>().houseUniqueIndex;

        if (houseZone == enemyFamiliarHouseZone) 
        {
            hasMessage = true;
            message ="Your hero landed in the enemy's familiar zone. You got attacked.";
        }
    }
}
