using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutOpenController : MonoBehaviour
{
    public GameObject[] cutAreas;
    // Start is called before the first frame update
    void Start()
    {
        cutAreas = GameObject.FindGameObjectsWithTag("CutPart");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void completeGame()
    {
        Destroy(this.gameObject);
    }
}
