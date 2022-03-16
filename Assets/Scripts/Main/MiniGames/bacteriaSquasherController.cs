using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bacteriaSquasherController : MonoBehaviour
{
    public int amountOfBacteria;
    public GameObject miniGameCanvas;
    public List<GameObject> _bacList;
    public GameObject _bac;
    public GameObject _bac1;
    public GameObject _bac2;
    public GameObject _bac3;
    public GameObject _bac4;

    private bool failMiniGame;

    // Start is called before the first frame update
    void Start()
    {
        BuildMiniGame();
        failMiniGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(amountOfBacteria <= 0)
        {
            Destroy(miniGameCanvas);
        }
    }

    public void subtractBacteria()
    {
        amountOfBacteria--;
    }

    public void BuildMiniGame()
    {
        amountOfBacteria = 5;
        int randNum = Random.Range(0, 3);
        switch (randNum)
        {
            case 0:
                _bacList.Add(_bac1);
                _bacList.Add(_bac1);
                _bacList.Add(_bac3);
                _bacList.Add(_bac2);
                _bacList.Add(_bac4);
                _bacList[4].GetComponent<BacteriaMovement>().badBac = true;
                break;
            case 1:
                _bacList.Add(_bac1);
                _bacList.Add(_bac1);
                _bacList.Add(_bac3);
                _bacList.Add(_bac2);
                _bacList.Add(_bac);
                _bacList[0].GetComponent<BacteriaMovement>().badBac = true;
                _bacList[1].GetComponent<BacteriaMovement>().badBac = true;

                break;
            case 2:
                _bacList.Add(_bac1);
                _bacList.Add(_bac3);
                _bacList.Add(_bac3);
                _bacList.Add(_bac4);
                _bacList.Add(_bac4);
                _bacList[1].GetComponent<BacteriaMovement>().badBac = true;
                _bacList[2].GetComponent<BacteriaMovement>().badBac = true;

                break;
            case 3:
                _bacList.Add(_bac);
                _bacList.Add(_bac1);
                _bacList.Add(_bac3);
                _bacList.Add(_bac2);
                _bacList.Add(_bac4);
                _bacList[1].GetComponent<BacteriaMovement>().badBac = true;
                _bacList[2].GetComponent<BacteriaMovement>().badBac = true;
                _bacList[3].GetComponent<BacteriaMovement>().badBac = true;
                _bacList[4].GetComponent<BacteriaMovement>().badBac = true;
                break;
            default:
                break;
        }   


        GameObject[] temp = GameObject.FindGameObjectsWithTag("spawnPointBac");
        for (int i = 0; i < _bacList.Count; i++)
        {
            var tempBac = Instantiate(_bacList[i], temp[i].transform);
            
        }
    }

    public void completeGame()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Bacteria");

        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i].GetComponent<BacteriaMovement>().badBac)
            {
                failMiniGame = true;
            }
        }
        if (failMiniGame)
        {
            GameObject.Find("GameController").GetComponent<GameControllerScript>().changeHealth(-1);
        }
        Destroy(miniGameCanvas);
    }

}
