using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePillController : MonoBehaviour
{
    public PatientInfo info;
    public GameObject[] pills;
    public bool failMiniGame;
    public DiseaseConstructScript diseaseConstructScript;
    // Start is called before the first frame update
    void Start()
    {
        info = GameObject.FindGameObjectWithTag("Patient").GetComponent<PatientInfo>();
        diseaseConstructScript = GameObject.Find("GameController").GetComponent<DiseaseConstructScript>();
        //pills = GameObject.FindGameObjectsWithTag("PillButtons");
        //pills = new GameObject[5];
        BuildMiniGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void completeGame()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("PillButtons");
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i].GetComponent<PillController>().takePill)
            {
                failMiniGame = true;
            }
        }
        if (failMiniGame)
        {
            GameObject.Find("GameController").GetComponent<GameControllerScript>().changeHealth(-1);
        }
        Destroy(this.gameObject);
    }

    public void BuildMiniGame()
    {
        if (!info.isMale)
        {
            pills[0].GetComponent<PillController>().takePill = true;
        }
        if (diseaseConstructScript.isBleeding)
        {
            pills[1].GetComponent<PillController>().takePill = true;
        }
        if (info.isRightName)
        {
            pills[2].GetComponent<PillController>().takePill = true;
        }
        if (info.isBorn)
        {
            pills[3].GetComponent<PillController>().takePill = true;
        }
        if (info.isIDEven)
        {
            pills[4].GetComponent<PillController>().takePill = true;
        }

    }
}
