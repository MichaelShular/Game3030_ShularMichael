using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IDCardController : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI idNumText;
    public TextMeshProUGUI BornText;
    public PatientInfo info;

    // Start is called before the first frame update
    void Start()
    {
        info = GameObject.FindGameObjectWithTag("Patient").GetComponent<PatientInfo>();

        nameText.text = info._name;
        idNumText.text = info.idNumber.ToString();
        BornText.text = "01 / " + info.bornNum.ToString() + " / 1990";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void backButton()
    {
        Destroy(this.gameObject);
    }
}
