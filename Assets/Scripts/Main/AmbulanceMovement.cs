using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmbulanceMovement : MonoBehaviour
{
    public float _moveSpeed;
    private float _interpolateAmount;
    public int streetChoice; 
    
    public GameObject _pointA;
    public GameObject[] _pointB;

    public GameObject _currentStreet;
    public GameObject _showUIChoice;

    public StreetType currentStreetChoice;
    public GameObject fadeImage;

    // Start is called before the first frame update
    void Start()
    {
        _interpolateAmount = 0.0f;
        _showUIChoice.SetActive(false);
        _pointB = new GameObject[3];
        streetChoice = 0;
        _pointB[0] = _currentStreet.GetComponent<StreetNextPosition>()._TopPointB;
        currentStreetChoice = StreetType.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (_interpolateAmount < 1)
        {
            _interpolateAmount = _interpolateAmount + _moveSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(_pointA.transform.position, _pointB[streetChoice].transform.position, _interpolateAmount);
            return;
        }


        _showUIChoice.SetActive(true);

    }

    private void setButtonChoice()
    {
        _currentStreet.GetComponent<StreetNextPosition>();
    }

    public enum StreetType
    { 
        None,
        Stright,
        Left,
        Right
    }

    public void strightButton()
    {
        currentStreetChoice = StreetType.Stright;
        StartCoroutine(startFade());
    }
    public void leftButton()
    {
        currentStreetChoice = StreetType.Left;
    }
    public void rightButton()
    {
        currentStreetChoice = StreetType.Right;
    }


    IEnumerator startFade()
    {
        float fadeAmount = 0;
        fadeImage.SetActive(true);
        while (fadeAmount <= 100)
        {
            fadeAmount += 0.01f;
            fadeImage.GetComponent<Image>().color = new Vector4(fadeImage.GetComponent<Image>().color.r, fadeImage.GetComponent<Image>().color.g, fadeImage.GetComponent<Image>().color.b, fadeAmount);
            yield return null;
        }
    }
}
