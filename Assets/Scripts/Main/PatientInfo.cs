using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientInfo : MonoBehaviour
{
    public bool isMale;
    public bool isIDEven;
    public bool isRightName;
    public bool isBorn;

    public int idNumber;
    public int bornNum;
    public string _name;
    public int _nameNUm;
    
    public List<string> listNames;

    // Start is called before the first frame update
    void Start()
    {
        isMale = false;
        buildScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buildScene()
    {
        idNumber = Random.Range(10000, 99999);
        bornNum = Random.Range(1, 31);
        _nameNUm = Random.Range(0, 10);
        

        if (idNumber % 2 == 0)
        {
            isIDEven = true;
        }

        if (bornNum < 20)
        {
            isBorn = true;
        }

        if(_nameNUm < 5)
        {
            isRightName = true;
        }
        _name = listNames[_nameNUm];

    }
}
