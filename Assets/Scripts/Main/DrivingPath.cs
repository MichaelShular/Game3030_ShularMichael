using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingPath : MonoBehaviour
{
    public List<StreetType> currentStreetTurnsPattern;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            int temp = Random.Range(0, 900);
            if(temp <= 300)
            {
                currentStreetTurnsPattern.Add(StreetType.Stright);
            }
            else if( temp > 300 && temp <= 600)
            {
                currentStreetTurnsPattern.Add(StreetType.Right);
            }
            else
            {
                currentStreetTurnsPattern.Add(StreetType.Left);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
