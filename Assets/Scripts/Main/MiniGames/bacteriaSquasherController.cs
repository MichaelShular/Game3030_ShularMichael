using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bacteriaSquasherController : MonoBehaviour
{
    public int amountOfBacteria;
    public GameObject miniGameCanvas;
    // Start is called before the first frame update
    void Start()
    {
        amountOfBacteria = 5;
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
}
