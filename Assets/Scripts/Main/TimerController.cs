using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    Slider UISlider;
    [SerializeField] private float maxTime;
    [SerializeField] private float currentTime;
    private IEnumerator coroutine ;
    public GameControllerScript gameController;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        UISlider = GetComponent<Slider>();
        UISlider.maxValue = maxTime;
        UISlider.value = 0;
        //StartTimer(5);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startTimer(float timer)
    {

        float animationTime = 0f;
        UISlider.value = timer;
        while (animationTime < timer)
        {
            animationTime += Time.deltaTime;
            float lerpValue = animationTime / timer;
            UISlider.value = Mathf.Lerp(timer, 0.0f, lerpValue);
            yield return null;
        }
        yield return null;
        gameController.checkGameState();
    }

    public void StartTimer(float lenght)
    {
        UISlider.maxValue = maxTime = lenght;
        coroutine = startTimer(maxTime);
        StartCoroutine(coroutine);
    }

    public void stopTimer()
    {
        StopCoroutine(coroutine);
    }

}
