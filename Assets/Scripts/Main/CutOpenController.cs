using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutOpenController : MonoBehaviour
{
    public GameObject[] cutAreasPositions;
    private GameObject gameController;
    public GameObject cutNode;
    public List<GameObject> cutNodeList;

    public int numberOfPressleft;
    public bool[] gameFailed;
    // Start is called before the first frame update
    void Start()
    {
        cutAreasPositions = GameObject.FindGameObjectsWithTag("CutPart");
        gameController = GameObject.Find("GameController");
        cutNodeList = new List<GameObject>();
        numberOfPressleft = 3;
        gameFailed = new bool[3] { false, false, false };

        buildMiniGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void completeGame()
    {
        bool checkIfResultNeedToOpen = true;
        foreach (bool check in gameFailed)
        {
            if (check)
            {
                //GameObject.Find("GameController").GetComponent<GameControllerScript>().changeHealth(-1);
                gameController.GetComponent<MiniGameResultScript>().OpenResultsUI(false);
                checkIfResultNeedToOpen = false;
                break;
            }
        }
        if (checkIfResultNeedToOpen)
        {
            gameController.GetComponent<MiniGameResultScript>().OpenResultsUI(true);
        }

        Destroy(this.gameObject);
    }

    private void buildMiniGame()
    {

        int tempNum = gameController.GetComponent<DiseaseConstructScript>().whichGameSet;
        foreach (GameObject item in cutAreasPositions)
        {
            GameObject temp = Instantiate(cutNode, this.transform);
            temp.transform.localPosition = item.transform.localPosition;
            temp.GetComponent<CutAreaController>().canPress = false;
            cutNodeList.Add(temp);
        }
        //Debug.Log(tempNum);
        switch (tempNum)
        {
            case 0:
                cutNodeList[4].GetComponent<CutAreaController>().canPress = true;
                cutNodeList[8].GetComponent<CutAreaController>().canPress = true;
                cutNodeList[10].GetComponent<CutAreaController>().canPress = true;

                break;
            case 1:
                cutNodeList[0].GetComponent<CutAreaController>().canPress = true;
                cutNodeList[2].GetComponent<CutAreaController>().canPress = true;
                cutNodeList[9].GetComponent<CutAreaController>().canPress = true;

                break;
            case 2:

                cutNodeList[1].GetComponent<CutAreaController>().canPress = true;
                cutNodeList[5].GetComponent<CutAreaController>().canPress = true;
                cutNodeList[7].GetComponent<CutAreaController>().canPress = true;

                break;
            case 3:
                cutNodeList[6].GetComponent<CutAreaController>().canPress = true;
                cutNodeList[3].GetComponent<CutAreaController>().canPress = true;
                cutNodeList[10].GetComponent<CutAreaController>().canPress = true;



                break;
            default:
                break;
        }
    }

    public void wasPressed(bool failGame)
    {
        numberOfPressleft--;
        if (numberOfPressleft < 0) return;
        gameFailed[numberOfPressleft] = failGame;
        
    }



}
