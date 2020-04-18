using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    public GameObject prompt;
    public Dice dice;

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
        QuestionHandler.AssignQuestionsToHouses(textFile);
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
            StartCoroutine(ChangeCamera(CameraEnum.Red));
        }
    }

    private IEnumerator ChangeCamera(CameraEnum cameraName)
    {
        red.GetComponent<Hero>().requestsCamera = false;
        yield return new WaitForSeconds(2);
        //mainCamera.enabled = false;
        switch (cameraName)
        {
            case CameraEnum.Red:
                redCamera.enabled = true;
                break;
            case CameraEnum.RedFamiliar:
                redFamiliarCamera.enabled = true;
                break;
            case CameraEnum.Blue:
                blueCamera.enabled = true;
                break;
            case CameraEnum.BlueFamiliar:
                blueFamiliarCamera.enabled = true;
                break;
            default:
                mainCamera.enabled = true;
                break;
        }
    }

    public void MoveHero()
    {
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

        mainCamera.enabled = true;
    }
}