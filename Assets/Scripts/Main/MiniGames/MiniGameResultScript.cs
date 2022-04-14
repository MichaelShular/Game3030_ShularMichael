using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGameResultScript : MonoBehaviour
{
    public bool wasCorrectMiniGameChoosen;
    public GameObject UIGameObject;

    // Start is called before the first frame update
    void Start()
    {
        wasCorrectMiniGameChoosen = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenResultsUI(bool miniGameFail)
    {

        Debug.Log("game right" + wasCorrectMiniGameChoosen + " was played right " + miniGameFail);
        UIGameObject.SetActive(true);

        if (!miniGameFail || !wasCorrectMiniGameChoosen)
        {
            UIGameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Your actions have caused\nthe patient condition to worsen.";
            GetComponent<GameControllerScript>().changeHealth(-1);
        }
        else
        {
            UIGameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Your actions help stabilize\nthe patient condition.";
        }

    }

    public void closeResultsUI()
    {
        UIGameObject.SetActive(false);
    }

}
