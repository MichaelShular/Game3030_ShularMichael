using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum areaType
{
    CuttingSection,
    Background
}
public class CutAreaController : MonoBehaviour
{
    public bool canPress;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CutAreaClickedOn()
    {
        if (canPress)
        {
            Debug.Log("cut");
        }

        Destroy(this.gameObject);
    }

    public void BackgroundClicked()
    {
        Debug.Log("back");
    }

}
