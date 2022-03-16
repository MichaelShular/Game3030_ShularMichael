using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameControllerScript : MonoBehaviour
{
    public GameObject timer;
    public GameObject GameState;
    public TextMeshProUGUI GameStateText;

    private int amountlives;
    public Slider UISlider;


    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        UISlider.value = UISlider.maxValue = amountlives = 3;
        GameState.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    public void gameStateOver(string text)
    {
        GameStateText.text = text;
        GameState.SetActive(true);
    }

    public void checkGameState()
    {
        amountlives--;
        UISlider.value = amountlives;     
        if(amountlives <= 0)
        {
            gameStateOver("Game Over\n\nYou took too much time");    
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

    public void changeHealth(int amount)
    {
        amountlives += amount;
        UISlider.value = amountlives;
        if (amountlives <= 0)
        {
            gameStateOver("Game Over\n\nYou took too much time");
        }
    }

}
