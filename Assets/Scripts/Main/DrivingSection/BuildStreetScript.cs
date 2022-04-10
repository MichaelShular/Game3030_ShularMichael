using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum WhichStreetLayout
{
    None,
    StrightLeft,
    StrightRight,
    LeftRight,
    AllStreets
}
public class BuildStreetScript : MonoBehaviour
{
    [Header("Street Lanes")]
    public GameObject straightLane;
    public GameObject LeftLane;
    public GameObject RightLane;

    [Header("Ambulance")]
    public GameObject ambulance;

    private int whichBuildingsToSpawn;
    private List<WhichStreetLayout> currentStreetTurnsPattern;
    private int currentStreetTurnsPatternCount;

    private StreetType CorrectButtonPress;

    private bool TopRightFilled;
    private bool TopLeftFilled;
    private bool BottomRightFilled;
    private bool BottomLeftFilled;

    [Header("Building And Props")]
    public List<GameObject> winVisuals;

    [Header("Street Name Lists")]
    public string winningStreetName;
    public List<string> ListA;
    public List<string> ListB;
    public List<string> ListC;
    public List<string> FillList;

    [Header("UI Buttons")]
    public List<GameObject> UIButtonList;



    void Start()
    {
        currentStreetTurnsPattern = new List<WhichStreetLayout>();
        

        for (int i = 0; i < 3; i++)
        {
            int temp = Random.Range(0, 4);
            switch (temp)
            {
                case 0:
                    currentStreetTurnsPattern.Add(WhichStreetLayout.StrightRight);
                    break;

                case 1:
                    currentStreetTurnsPattern.Add(WhichStreetLayout.StrightLeft);
                    break;

                case 2:
                    currentStreetTurnsPattern.Add(WhichStreetLayout.LeftRight);
                    break;

                case 3:
                    currentStreetTurnsPattern.Add(WhichStreetLayout.AllStreets);

                    break;
                default:
                    break;
            }
        }

        BuildStreet();
    }

    public void BuildStreet()
    {
        int temp;
        currentStreetTurnsPatternCount = ambulance.GetComponent<AmbulanceMovement>().currentStreetCount;
        BottomLeftFilled = BottomRightFilled = TopLeftFilled = TopRightFilled = false;
        whichBuildingsToSpawn = Random.Range(0, 4);
        RightLane.SetActive(true);
        LeftLane.SetActive(true);
        straightLane.SetActive(true);

        //Give all UI button default names
        foreach (var UIButton in UIButtonList)
        {
            int tempNumber = Random.Range(0, FillList.Count);
            string randomName = FillList[tempNumber];
            UIButton.GetComponentInChildren<TextMeshProUGUI>().text = randomName;
        }


        switch (currentStreetTurnsPattern[currentStreetTurnsPatternCount])
        {
            case WhichStreetLayout.None:
                break;
            case WhichStreetLayout.StrightLeft:
                //streetLamps
                winVisuals[11].gameObject.SetActive(true);

                RightLane.SetActive(false);
                winningStreetName = StrightLeftSection();

                temp = Random.Range(0, 2);
                if(temp == 0) 
                {
                    UIButtonList[0].GetComponentInChildren<TextMeshProUGUI>().text = winningStreetName;
                }
                else
                {
                    UIButtonList[1].GetComponentInChildren<TextMeshProUGUI>().text = winningStreetName;
                }

                break;
            case WhichStreetLayout.StrightRight:
                //streetLamps
                winVisuals[11].gameObject.SetActive(true);


                LeftLane.SetActive(false);
                winningStreetName = StrightRightSection();

                temp = Random.Range(0, 2);
                if (temp == 0)
                {
                    UIButtonList[0].GetComponentInChildren<TextMeshProUGUI>().text = winningStreetName;
                }
                else
                {
                    UIButtonList[2].GetComponentInChildren<TextMeshProUGUI>().text = winningStreetName;
                }

                break;
            case WhichStreetLayout.LeftRight:
                TopLeftFilled = true;
                winVisuals[4].gameObject.SetActive(true);


                straightLane.SetActive(false);
                winningStreetName = RightLeftSection();
                temp = Random.Range(0, 2);
                if (temp == 0)
                {
                    UIButtonList[1].GetComponentInChildren<TextMeshProUGUI>().text = winningStreetName;
                }
                else
                {
                    UIButtonList[2].GetComponentInChildren<TextMeshProUGUI>().text = winningStreetName;
                }

                break;
            case WhichStreetLayout.AllStreets:
                //Cones
                winVisuals[14].gameObject.SetActive(true);

                //streetLamps
                winVisuals[11].gameObject.SetActive(true);

                winningStreetName = AllStreetSection();
                temp = Random.Range(0, 3);
                if (temp == 0)
                {
                    UIButtonList[0].GetComponentInChildren<TextMeshProUGUI>().text = winningStreetName;
                }
                else if( temp == 1)
                {
                    UIButtonList[1].GetComponentInChildren<TextMeshProUGUI>().text = winningStreetName;
                }
                else
                {
                    UIButtonList[2].GetComponentInChildren<TextMeshProUGUI>().text = winningStreetName;

                }

                break;
            default:
                break;
        }
    }

    private string StrightLeftSection()
    {
        string streetName = "null";
        switch (whichBuildingsToSpawn)
        {
            case 0:
                streetName = RandomNameFromList(ListC);
                break;
            case 1:
                TopRightFilled = true;
                BottomLeftFilled = true;
                BottomRightFilled = true;
                streetName = RandomNameFromList(ListA);
                winVisuals[1].gameObject.SetActive(true);
                winVisuals[6].gameObject.SetActive(true);
                winVisuals[9].gameObject.SetActive(true);

                break;
            case 2:
                TopRightFilled = true;
                winVisuals[0].gameObject.SetActive(true);
                streetName = RandomNameFromList(ListC);
                break;

            case 3:
                TopRightFilled = true;
                winVisuals[0].gameObject.SetActive(true);
                streetName = RandomNameFromList(ListB);

                break;
            default:
                break;
        }

        return streetName;
    }

    private string StrightRightSection()
    {
        string streetName = "null";
        switch (whichBuildingsToSpawn)
        {
            case 0:
                streetName = RandomNameFromList(ListA);
                winVisuals[15].gameObject.SetActive(true);
                winVisuals[11].gameObject.SetActive(false);

                break;
            case 1:
                TopLeftFilled = true;
                streetName = RandomNameFromList(ListB);
                winVisuals[4].gameObject.SetActive(true);



                break;
            case 2:
                int tempNum = Random.Range(0, 2);
                if (tempNum == 0)
                {
                    BottomLeftFilled = true;
                    winVisuals[5].gameObject.SetActive(true);
                }
                else
                {
                    winVisuals[4].gameObject.SetActive(true);
                }


                streetName = RandomNameFromList(ListA);


                break;

            case 3:                
                streetName = RandomNameFromList(ListB);

                break;
            default:
                break;
        }

        return streetName;
    }

    private string RightLeftSection()
    {
        string streetName = "null";
        switch (whichBuildingsToSpawn)
        {
            case 0:
                streetName = RandomNameFromList(ListB);
                TopRightFilled = true;
                winVisuals[0].gameObject.SetActive(true);
                winVisuals[2].gameObject.SetActive(true);
                break;
            case 1:
                streetName = RandomNameFromList(ListC);
                TopLeftFilled = false;
                winVisuals[4].gameObject.SetActive(false);


                break;
            case 2:
                streetName = RandomNameFromList(ListC);
                BottomLeftFilled = true;
                BottomRightFilled = true;
                winVisuals[7].gameObject.SetActive(true);
                winVisuals[10].gameObject.SetActive(true);
                break;

            case 3:
                streetName = RandomNameFromList(ListA);
                TopRightFilled = true;
                winVisuals[0].gameObject.SetActive(true);
                

                break;
            default:
                break;
        }

        return streetName;
    }

    private string AllStreetSection()
    {
        string streetName = "null";
        switch (whichBuildingsToSpawn)
        {
            case 0:
                streetName = RandomNameFromList(ListA);
                winVisuals[13].gameObject.SetActive(true);
                winVisuals[14].gameObject.SetActive(false);

                break;
            case 1:
                streetName = RandomNameFromList(ListB);
                TopRightFilled = true;
                BottomLeftFilled = true;
                BottomRightFilled = true;
                winVisuals[3].gameObject.SetActive(true);
                winVisuals[7].gameObject.SetActive(true);
                winVisuals[10].gameObject.SetActive(true);



                break;
            case 2:
                streetName = RandomNameFromList(ListB);
                BottomLeftFilled = true;
                winVisuals[8].gameObject.SetActive(true);
                break;

            case 3:
                streetName = RandomNameFromList(ListC);


                break;
            default:
                break;
        }

        return streetName;
    }



    private string RandomNameFromList(List<string> streetNameList)
    {
        int temp = Random.Range(0, streetNameList.Count);
        return streetNameList[temp];
    }

    private void AddingStreetNamesToUI(List<string> streetNameList )
    {


    }


    private void ResetStreet()
    {

    } 

}
