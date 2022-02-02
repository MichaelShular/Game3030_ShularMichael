using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameControllerScript : MonoBehaviour
{
    public GameObject timer;
    public TextMeshProUGUI GameState;
    private int amountlives;


    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        amountlives = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    public void gameStateOver()
    {
        GameState.text = "Game Over";
        GameState.enabled = true;
    }

    public void checkGameState()
    {
        amountlives--;
        if(amountlives <= 0)
        {
            gameStateOver();    
        }
        else
        {
            timer.GetComponent<TimerController>().StartTimer(5);
        }
    }
    public void StopTimer()
    {
        timer.GetComponent<TimerController>().stopTimer();
    }

}
