using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
public class AmbulanceMovement : MonoBehaviour
{
    public float _moveSpeed;
    private float _interpolateAmount;

    public GameObject _pointA;
    public GameObject _pointB;
    public GameObject _startB;
    public GameObject _startA;

    public GameObject _currentStreet;
    public GameObject _showUIChoice;

    public string StreetNameCheck;
    public GameObject fadeImage;

    bool canTurn;
    public TextMeshProUGUI displayResult;
    private GameObject gameController;
    public int currentStreetCount;

    public GameObject streetOne;
    public GameObject streetTwo;
    public GameObject streetThree;

    public GameObject _striaghtButton;
    public GameObject _leftButton;
    public GameObject _rightButton;

    public GameObject FirstPersonCamera;
    public GameObject spawnPoint;

    //public GameObject lamp;
    //public GameObject Building;
    //public GameObject fireHy;


    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");
        _interpolateAmount = 0.0f;
        _showUIChoice.SetActive(false);
        _pointB = _currentStreet.GetComponent<StreetNextPosition>()._TopPointB;
        StreetNameCheck = "";
        canTurn = false;
        _startA = _pointA;
        _startB = _pointB;
        currentStreetCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(currentStreetCount == gameController.GetComponent<BuildStreetScript>().numberOfTurns)
        {
            return;
        }

        if (_interpolateAmount < 1)
        {
            _interpolateAmount = _interpolateAmount + _moveSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(_pointA.transform.position, _pointB.transform.position, _interpolateAmount);
            return;
        }

        //if(_interpolateAmount < 1 && (currentStreetChoice == StreetType.Left || currentStreetChoice == StreetType.Right))
        //{


        //    _interpolateAmount = _interpolateAmount + _moveSpeed * Time.deltaTime;

        //    if (canTurn)
        //    {
        //        if (currentStreetChoice == StreetType.Left)
        //        {
        //            if (transform.rotation.eulerAngles.y > 270 || transform.rotation.eulerAngles.y == 0)
        //            {
        //                transform.Rotate(0, -0.2f, 0);
        //            }
        //        }
        //        else
        //        {
        //            if (transform.rotation.eulerAngles.y < 90 || transform.rotation.eulerAngles.y == 0)
        //            {
        //                transform.Rotate(0, +0.2f, 0);
        //            }
        //        }
        //    }


        //    Debug.Log(transform.rotation.eulerAngles.y);

        //    transform.position = CubicLerp(_pointA.transform.position, _pointATurnPoint.transform.position, _pointBTurnPoint.transform.position, _pointB.transform.position, _interpolateAmount);
        //    if(_interpolateAmount >= 1)
        //    {
        //        _interpolateAmount = 0;
        //    } 

        //    return;
        //}
        _showUIChoice.SetActive(true);
        //Debug.Log(fadeImage.GetComponent<Image>().color.a);
        if (fadeImage.GetComponent<Image>().color.a >= 0.8)
        {
            StartCoroutine(startUnfade());
        }

    }

    private void setButtonChoice()
    {
        _currentStreet.GetComponent<StreetNextPosition>();
    }



    public void strightButton()
    {
        StreetNameCheck = _striaghtButton.GetComponentInChildren<TextMeshProUGUI>().text;
        _pointA = _pointB;
        _pointB = _currentStreet.GetComponent<StreetNextPosition>()._strightStreet.GetComponent<StreetNextPosition>()._TopPointB;
        _interpolateAmount = 0;
        StartCoroutine(startFade());
    }
    public void leftButton()
    {
        StreetNameCheck = _leftButton.GetComponentInChildren<TextMeshProUGUI>().text;
        _pointA = _pointB;
        _pointB = _currentStreet.GetComponent<StreetNextPosition>()._leftStreet.GetComponent<StreetNextPosition>()._TopPointA;
        StartCoroutine(startFade());

        //_pointATurnPoint = GameObject.Find("TurnLeft");
        _interpolateAmount = 0;
        //StartCoroutine(startTurn());
    }
    public void rightButton()
    {
        StreetNameCheck = _rightButton.GetComponentInChildren<TextMeshProUGUI>().text;

        _pointA = _pointB;
        _pointB = _currentStreet.GetComponent<StreetNextPosition>()._rightStreet.GetComponent<StreetNextPosition>()._BottomPointA;
        StartCoroutine(startFade());

        //_pointATurnPoint = GameObject.Find("TurnRight");
        _interpolateAmount = 0;
    }


    IEnumerator startFade()
    {
        float fadeAmount = 0;
        fadeImage.SetActive(true);
        buildResult();
        while (fadeAmount <= 1)
        {
            fadeAmount += 0.005f;
            fadeImage.GetComponent<Image>().color = new Vector4(fadeImage.GetComponent<Image>().color.r, fadeImage.GetComponent<Image>().color.g, fadeImage.GetComponent<Image>().color.b, fadeAmount);
            yield return null;
        }

    }

    IEnumerator startUnfade()
    {
        float fadeAmount = 0.8f;
        ResetstreetChoice();
        gameController.GetComponent<BuildStreetScript>().ResetStreet();

        //buildStreetObjects();
        gameController.GetComponent<BuildStreetScript>().BuildStreet();
        while (fadeAmount >= 0)
        {
            fadeAmount -= 0.01f;
            fadeImage.GetComponent<Image>().color = new Vector4(fadeImage.GetComponent<Image>().color.r, fadeImage.GetComponent<Image>().color.g, fadeImage.GetComponent<Image>().color.b, fadeAmount);
            yield return null;
        }
    }

    IEnumerator startTurn()
    {
        yield return new WaitForSeconds(0.1f);
        canTurn = true;
    }

    private Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(b, c, t);
        return Vector3.Lerp(ab, bc, _interpolateAmount);
    }
    private Vector3 CubicLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        Vector3 ab_bc = QuadraticLerp(a, b, c, t);
        Vector3 bc_cd = QuadraticLerp(b, c, d, t);
        return Vector3.Lerp(ab_bc, bc_cd, _interpolateAmount);
    }

    private void ResetstreetChoice()
    {
        _interpolateAmount = 0.0f;
        _showUIChoice.SetActive(false);
        _pointB = _currentStreet.GetComponent<StreetNextPosition>()._TopPointB;
        StreetNameCheck = "";
        canTurn = false;
        fadeImage.SetActive(false);

        _pointA = _startA;
        _pointB = _startB;


        //vvvv Needs to be above the if statement vvvv 
        currentStreetCount++;
        
        //Next Gamemode
        if (currentStreetCount == gameController.GetComponent<BuildStreetScript>().numberOfTurns)
        {
            streetOne.SetActive(false);
            streetTwo.SetActive(false);
            streetThree.SetActive(false);
            this.transform.position = spawnPoint.transform.position;
            FirstPersonCamera.GetComponent<CinemachineVirtualCamera>().Priority = 15;
            gameController.GetComponent<DiseaseConstructScript>().checkToAddedBloodUI();
        }
        
        
        
        
    }

    private void buildResult()
    {
        //add or sub time
        if (gameController.GetComponent<BuildStreetScript>().winningStreetName == StreetNameCheck)
        {
            displayResult.text = "";
        }
        else
        {
            gameController.GetComponent<GameControllerScript>().changeHealth(-1);
            displayResult.text = "Took a wrong turn\n\nThe patient condition worsens";
        }
    }

    public void buildStreetObjects()
    {
        //int numberOfStreets = Random.Range(0, 100);
        streetOne.SetActive(true);
        streetTwo.SetActive(true);
        streetThree.SetActive(true);
        _striaghtButton.SetActive(true);
        _rightButton.SetActive(true);
        _leftButton.SetActive(true);
        //lamp.SetActive(false);
        //fireHy.SetActive(false);
        //Building.SetActive(false);
        //switch (gameController.GetComponent<DrivingPath>().currentStreetTurnsPattern[currentStreetCount])
        //{
        //    case StreetType.None:
        //        break;
        //    case StreetType.Stright:
        //        Building.SetActive(true);
        //        if (numberOfStreets <= 50 && numberOfStreets > 25)
        //        {

        //            streetThree.SetActive(false);
        //            _leftButton.SetActive(false);
        //        }
        //        else if (numberOfStreets < 25)
        //        {

        //            streetTwo.SetActive(false);
        //            _rightButton.SetActive(false);
        //        }
        //        break;
        //    case StreetType.Left:
        //        fireHy.SetActive(true);
        //        if (numberOfStreets <= 50 && numberOfStreets > 25)
        //        {
        //            streetOne.SetActive(false);
        //            _striaghtButton.SetActive(false);
        //        }
        //        else if (numberOfStreets < 25)
        //        {
        //            streetTwo.SetActive(false);
        //            _rightButton.SetActive(false);
        //        }
        //        break;
        //    case StreetType.Right:
        //        lamp.SetActive(true);
        //        if (numberOfStreets <= 50 && numberOfStreets > 25)
        //        {
        //            streetThree.SetActive(false);
        //            _leftButton.SetActive(false);
        //        }
        //        else if (numberOfStreets < 25)
        //        {
        //            streetOne.SetActive(false);
        //            _striaghtButton.SetActive(false);
        //        }
        //        break;
        //    default:
        //        break;
        //}
    }

}
