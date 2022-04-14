using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ConditionSelectionController : MonoBehaviour
{

    public GameObject UIGameObject;
    public GameObject gameController;
    public TextMeshProUGUI titletext;

    // Start is called before the first frame update
    void Start()
    {
        UIGameObject = GameObject.Find("FinalResults");
        titletext = GameObject.Find("WinLose").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ButtonOne()
    {
        UIGameObject.SetActive(true);
        if (gameController.GetComponent<DiseaseConstructScript>().whichGameSet == 0)
        {
            titletext.text = "Winner, you gave the patient the right diagnosis.";
        }
        else
        {
            titletext.text = "You gave the patient the wrong diagnosis.";

        }
        Destroy(this.gameObject);
    }

    public void ButtonTwo()
    {
        UIGameObject.SetActive(true);
        if (gameController.GetComponent<DiseaseConstructScript>().whichGameSet == 1)
        {
            titletext.text = "Winner, you gave the patient the right diagnosis.";


        }
        else
        {
            titletext.text = "You gave the patient the wrong diagnosis.";

        }
        Destroy(this.gameObject);

    }

    public void ButtonThree()
    {
        UIGameObject.SetActive(true);
        if (gameController.GetComponent<DiseaseConstructScript>().whichGameSet == 2)
        {
            titletext.text = "Winner, you gave the patient the right diagnosis.";


        }
        else
        {
            titletext.text = "You gave the patient the wrong diagnosis.";

        }
        Destroy(this.gameObject);

    }

    public void ButtonFour()
    {
        UIGameObject.SetActive(true);
        if (gameController.GetComponent<DiseaseConstructScript>().whichGameSet == 3)
        {
            titletext.text = "Winner, you gave the patient the right diagnosis.";


        }
        else
        {
            titletext.text = "You gave the patient the wrong diagnosis.";

        }
        Destroy(this.gameObject);

    }

}
