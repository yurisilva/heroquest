using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    public GameObject prompt;
    public Button buttonRollDice;
    public Dice dice;

    private Camera enabledCamera;
    public Camera mainCamera;
    public Camera redCamera;
    public Camera redFamiliarCamera;
    public Camera blueCamera;
    public Camera blueFamiliarCamera;
    private Camera[] cameras = new Camera[5];

    GameObject playingHero;
    float moveSpeed = 6.0f;

    void Start()
    {
        Table.InitializeTable();
        LoadCameras();
        PlacePiecesOnTheBoard();
        LoadQuestions();
    }

    private void LoadQuestions()
    {
        TextAsset textFile = Resources.Load<TextAsset>("questions");
        QuestionHelper.AssignQuestionsToHouses(textFile);
    }

    void Update()
    {
        if (red.GetComponent<Hero>().hasMessage)
        {
            red.GetComponent<Hero>().hasMessage = false;
            prompt.GetComponent<Text>().text = red.GetComponent<Hero>().message;
            prompt.SetActive(true);
        }

        if (blue.GetComponent<Hero>().hasMessage)
        {
            blue.GetComponent<Hero>().hasMessage = false;
            prompt.GetComponent<Text>().text = blue.GetComponent<Hero>().message;
            prompt.SetActive(true);
        }

        if (red.GetComponent<Hero>().requestsCamera)
        {
            StartCoroutine(ChangeCameraFocusTo(CameraEnum.Red));
        }

        if (blue.GetComponent<Hero>().requestsCamera)
        {
            StartCoroutine(ChangeCameraFocusTo(CameraEnum.Blue));
        }

        if (playingHero.GetComponent<Hero>().questionCanvas.GetComponent<QuestionCanvas>().turnIsOver)
        {
            playingHero.GetComponent<Hero>().questionCanvas.GetComponent<QuestionCanvas>().turnIsOver = false;
            StartCoroutine(ChangeCameraFocusTo(CameraEnum.Main));
            buttonRollDice.enabled = true;
            TogglePlayer();
        }
    }

    private void UnloadQuestionCanvas()
    {
        playingHero.GetComponent<Hero>().questionCanvas.GetComponent<QuestionCanvas>().questionOutput.GetComponent<Text>().text = string.Empty;
        playingHero.GetComponent<Hero>().questionCanvas.GetComponent<QuestionCanvas>().Answer1Output.GetComponent<Button>().GetComponent<AnswerButton>().answer = null;
        playingHero.GetComponent<Hero>().questionCanvas.GetComponent<QuestionCanvas>().Answer2Output.GetComponent<Button>().GetComponent<AnswerButton>().answer = null;
        playingHero.GetComponent<Hero>().questionCanvas.GetComponent<QuestionCanvas>().Answer3Output.GetComponent<Button>().GetComponent<AnswerButton>().answer = null;
        playingHero.GetComponent<Hero>().questionCanvas.GetComponent<QuestionCanvas>().Answer4Output.GetComponent<Button>().GetComponent<AnswerButton>().answer = null;
    }

    private IEnumerator ChangeCameraFocusTo(CameraEnum cameraName)
    {
        yield return new WaitForSeconds(1);
        enabledCamera.enabled = false;

        switch (cameraName)
        {
            case CameraEnum.Red:
                red.GetComponent<Hero>().requestsCamera = false;
                red.GetComponent<Hero>().questionCanvas.SetActive(true);
                enabledCamera = redCamera;
                redCamera.enabled = true;
                break;
            case CameraEnum.RedFamiliar:
                enabledCamera = redFamiliarCamera;
                redFamiliarCamera.enabled = true;
                break;
            case CameraEnum.Blue:
                blue.GetComponent<Hero>().requestsCamera = false;
                blue.GetComponent<Hero>().questionCanvas.SetActive(true);
                enabledCamera = blueCamera;
                blueCamera.enabled = true;
                break;
            case CameraEnum.BlueFamiliar:
                enabledCamera = blueFamiliarCamera;
                blueFamiliarCamera.enabled = true;
                break;
            default:
                red.GetComponent<Hero>().questionCanvas.SetActive(false);
                blue.GetComponent<Hero>().questionCanvas.SetActive(false);
                enabledCamera = mainCamera;
                mainCamera.enabled = true;
                break;
        }
    }

    public void MoveHero()
    {
        buttonRollDice.enabled = false;
        playingHero.GetComponent<Hero>().GetComponent<Hero>().Move(moveSpeed, dice.diceResult);
    }

    public void MoveFamiliar()
    {
        playingHero.GetComponent<Hero>().familiar.GetComponent<Familiar>().Move(moveSpeed, dice.diceResult);
    }

    public void TogglePlayer()
    { 
        if (playingHero.name == red.name)
        {
            playingHero = GetPlayingCharacter(blue.name);
        }
        else
        {
            playingHero = GetPlayingCharacter(red.name);
        }
    }

    private GameObject GetPlayingCharacter(string name)
    {
        return name == red.name ? red : blue;
    }

    private void PlacePiecesOnTheBoard()
    {
        playingHero = red;

        Table.GetHouse(1).SetPlayerOccupyingHouse(red);
        Table.GetHouse(15).SetPlayerOccupyingHouse(blue);

        red.GetComponent<Hero>().nextHouse = Table.GetHouse(2);
        blue.GetComponent<Hero>().nextHouse = Table.GetHouse(16);

        red.GetComponent<Hero>().familiar.transform.position = Table.GetFamiliarHouse(1).FamiliarPositionInThisHouse();
        red.GetComponent<Hero>().familiar.GetComponent<Familiar>().houseUniqueIndex = Table.GetFamiliarHouse(1).GetComponent<FamiliarHouse>().uniqueIndex;

        blue.GetComponent<Hero>().familiar.transform.position = Table.GetFamiliarHouse(1).opposingHouse.FamiliarPositionInThisHouse();
        blue.GetComponent<Hero>().familiar.GetComponent<Familiar>().houseUniqueIndex = Table.GetFamiliarHouse(1).opposingHouse.GetComponent<FamiliarHouse>().uniqueIndex;
    }

    private void LoadCameras()
    {
        cameras[0] = mainCamera;
        cameras[1] = redCamera;
        cameras[2] = redFamiliarCamera;
        cameras[3] = blueCamera;
        cameras[4] = blueFamiliarCamera;

        foreach (var cam in cameras)
        {
            cam.enabled = false;
        }

        enabledCamera = mainCamera;
        mainCamera.enabled = true;
    }
}